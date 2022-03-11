// 何翔华
// Taf.Core.Net.Web
// Home.cs

using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using SshNet.Security.Cryptography;
using System.Diagnostics.CodeAnalysis;
using Taf.Core.Net.Tools.Domain;
using Taf.Core.Net.Tools.Domain.Share;
using Taf.Core.Net.Tools.Services;
using Taf.Core.Net.Utility.Exception;
using Taf.Core.Utility;

namespace Taf.Core.Net.Web.Controllers;

/// <summary>
/// 签名服务
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SignatureController : ControllerBase{
    private readonly IConfiguration   _configuration;
    private readonly IShortUrlService _shortUrlService;
    private readonly ISignService     _signService;

    // GET
    public SignatureController(
        IConfiguration   configuration
      , IShortUrlService shortUrlService
      , ISignService     signService){
        _configuration   = configuration;
        _shortUrlService = shortUrlService;
        _signService     = signService;
    }

    [HttpGet]
    [Route("auth/")]
    public async Task<IActionResult> Get(string appId, string? userId, string timestamp, string sign, string? callback){
        try{
            if(string.IsNullOrWhiteSpace(appId)
            || string.IsNullOrWhiteSpace(timestamp)
            || string.IsNullOrWhiteSpace(sign)){
                return new UnauthorizedResult(); //参数缺失
            }

            appId = appId.Replace("-", "");
            var shortUrl = new ShorUrlCreateDto(){
                Callback      = callback
              , Source        = SignClientSource.Aliyun
              , AppId         = appId
              , SourceUrl     = HttpContext.Request.GetEncodedUrl()
              , TargetUrl     = _configuration["ShortCode:Prefix"]
              , UserId        = userId
              , ExpiraionDate = DateTime.Now.AddHours(1)
            };

            var appKey = await _signService.GetAppKeyById(appId.Trim());
            if(appKey == null){
                return new UnauthorizedResult(); //未找到客户 
            }

            if(sign != Encrypt.Md5By16($"{appKey}{timestamp.Trim()}{userId?.Trim() ?? string.Empty}")){
                return new UnauthorizedResult(); //鉴权失败
            }

            // var date = ConvertStringToDateTime(timestamp);
            // if(date.AddHours(1) < DateTime.Now){
            //     return new UnauthorizedResult(); //时间过期
            // }

            var targeturl = await _shortUrlService.ShortUrlGenerator(shortUrl);
            if(!string.IsNullOrWhiteSpace(userId)){
                await _signService.CreateUser(shortUrl.AppId, shortUrl.UserId);
            }

            return Redirect(targeturl); 
        } catch(Exception ex){
            return new UnauthorizedResult();//其他错误
        }
    }

    /// <summary>
    /// 获取Java 13位时间戳转DateTime
    /// </summary>
    /// <param name="timeStamp"></param>
    /// <returns></returns>
    private DateTime ConvertStringToDateTime(string timeStamp){
        DateTime ConvertString(int length){
            var dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            var lTime   = long.Parse(timeStamp + new string('0',length));
            var toNow   = new TimeSpan(lTime);
            return dtStart.Add(toNow); 
        }
        if(timeStamp.Length == 13){
            return ConvertString(4);
        } else if(timeStamp.Length == 18){
            return new DateTime(timeStamp.ToLong());
        }else if(timeStamp.Length==10){
            return ConvertString(7); 
        }

        throw new CustomException("不支持该时间格式", new Guid("5F80BA88-DD2F-4756-8457-E621BABC523E"));
    }
}
