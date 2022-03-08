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
using Taf.Core.Net.Utility.Database;

// 何翔华
// Taf.Core.Net.Tools
// ShortUrlService.cs

namespace Taf.Core.Net.Tools.Services;

using System;

/// <summary>
/// 短链服务
/// </summary>
public class ShortUrlService : IShortUrlService{
    private readonly IRepository<ShortUrl, Guid> _shortUrlRepository;
    public ShortUrlService(IRepository<ShortUrl, Guid> shortUrlRepository) => _shortUrlRepository = shortUrlRepository;

    public async Task<string> ShortUrlGenerator(string url, DateTime? expiraionDate = null){
        var    head     = Regex.Match(url, @"(\w+:\/\/)([^/:]+)(:\d*)?");
        byte[] srcBytes = Encoding.UTF8.GetBytes(url);
        // HashSizeInBits=32 or 128
        var cfg       = new MurmurHash3Config(){ HashSizeInBits = 32, Seed = 0 };
        var mur       = MurmurHash3Factory.Instance.Create(cfg);
        var hv        = mur.ComputeHash(srcBytes);
        var base64    = hv.AsBase64String();
        var hashBytes = hv.Hash;
        var code      = mur.ComputeHash(hashBytes).AsHexString();
        if(await _shortUrlRepository.CountAsync(r => r.ShortCode == code && (r.ExpiraionDate.HasValue==null || r.ExpiraionDate > DateTime.UtcNow)) > 0){
            code = await ShortUrlGenerator($"{url}&d={DateTimeOffset.UtcNow.ToUnixTimeSeconds()}", DateTime.UtcNow);
        } else{
            await _shortUrlRepository.InsertAsync(new ShortUrl(){ OriginalUrl = url, ExpiraionDate = expiraionDate, ShortCode = code, TotalClickCount = 0 });
        }

        return $"{head}/{code}";
    }
}
