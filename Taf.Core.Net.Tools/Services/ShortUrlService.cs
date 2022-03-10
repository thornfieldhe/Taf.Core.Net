// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShortUrlService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using SqlSugar;
using System.Collections.Generic;
using System.Data.HashFunction.MurmurHash;
using System.Text;
using System.Text.RegularExpressions;
using Taf.Core.Net.Tools.Domain;
using Taf.Core.Net.Tools.Domain.Share;
using Taf.Core.Net.Utility.Database;
using Taf.Core.Net.Utility.Exception;
using Taf.Core.Net.Utility.Paging;

// 何翔华
// Taf.Core.Net.Tools
// ShortUrlService.cs

namespace Taf.Core.Net.Tools.Services;

using System;

/// <summary>
/// 短链服务
/// </summary>
public class ShortUrlService : IShortUrlService{
    private readonly IRepository<ShortUrl> _shortUrlRepository;
    public ShortUrlService(IRepository<ShortUrl> shortUrlRepository) => _shortUrlRepository = shortUrlRepository;

    public async Task<string> ShortUrlGenerator(ShorUrlCreateDto input){
        var code      = GethashCode(input.SourceUrl);
        if(await _shortUrlRepository.CountAsync(r => r.ShortCode == code && (r.ExpirationDate == null || r.ExpirationDate > DateTime.Now)) > 0){
            input.SourceUrl = $"{input.SourceUrl}&d={DateTimeOffset.Now.ToUnixTimeSeconds()}";
            return await ShortUrlGenerator(input);
        } else{
            var targetUrl = $"{input.TargetUrl}/{code}";
            await _shortUrlRepository.InsertAsync(new ShortUrl(){
                                                      OriginalUrl     = input.SourceUrl
                                                    , ExpirationDate  = input.ExpiraionDate
                                                    , ShortCode       = code
                                                    , TotalClickCount = 0
                                                    , Source          = input.Source.ToString()
                                                    , CallBack        = input.Callback
                                                    , Targeturl       = targetUrl
                                                  });
            return targetUrl;
        }
    }

    public async Task<PagedResultDto<ShortUrlListDto>> GetAllList(BaseQueryRequestDto query){
        return await _shortUrlRepository.Page<ShortUrlListDto>(query, (s) => string.IsNullOrEmpty(query.KeyWord)
                                                                          || s.OriginalUrl.Contains(query.KeyWord)
                                                                          || s.ShortCode.Contains(query.KeyWord));
    }
    
    private string GethashCode(string code){
        var srcBytes = Encoding.UTF8.GetBytes(code);
        // HashSizeInBits=32 or 128
        var cfg       = new MurmurHash3Config(){ HashSizeInBits = 32, Seed = 0 };
        var mur       = MurmurHash3Factory.Instance.Create(cfg);
        var hv        = mur.ComputeHash(srcBytes);
        var base64    = hv.AsBase64String();
        var hashBytes = hv.Hash;
        return    mur.ComputeHash(hashBytes).AsHexString(); 
    }
}
