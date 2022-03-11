// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShortUrlService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using EfootprintV3.Database.Domain;
using EfootprintV3.Database.Domain.Share;
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
    private readonly IRepository<ShortUrl>          _shortUrlRepository;
    private readonly IRepository<UserWithShortCode> _userWithShortCodeRepository;

    public ShortUrlService(IRepository<ShortUrl> shortUrlRepository
                          ,IRepository<UserWithShortCode> userWithShortCodeRepository){
        _shortUrlRepository               = shortUrlRepository;
        _userWithShortCodeRepository = userWithShortCodeRepository;
    }

    public async Task<(string TargetUrl,string ShortCode)> ShortUrlGenerator(ShorUrlCreateDto input){
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
            return (targetUrl,code);
        }
    }

    public async Task<PagedResultDto<ShortUrlListDto>> GetAllList(BaseQueryRequestDto query){
        return await _shortUrlRepository.Page<ShortUrlListDto>(query, (s) => string.IsNullOrEmpty(query.KeyWord)
                                                                          || s.OriginalUrl.Contains(query.KeyWord)
                                                                          || s.ShortCode.Contains(query.KeyWord));
    }
    
    /// <summary>
    /// 创建用户调用结构
    /// </summary>
    public async Task CreatUserCallingInfo(UserWithShortCodeDto user) =>
        await _userWithShortCodeRepository.InsertAsync(new UserWithShortCode(){
            AppId = user.AppId, ExpirationDate = user.ExpirationDate, ShortCode = user.ShortCode.Trim(), UserId = user.UserId.Trim()
        });
    
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
