// 何翔华
// Taf.Core.Net.Web
// Home.cs

using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using Taf.Core.Net.Tools.Services;

namespace Taf.Core.Net.Web.Controllers;

/// <summary>
/// 签名服务
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SignatureController : ControllerBase{
    private readonly IShortUrlService _shortUrlService;

    // GET
    public SignatureController( IShortUrlService shortUrlService){
        _shortUrlService = shortUrlService;
    }

    [HttpGet]
    [Route("api/signature/")]
    public async Task<string> Get(string appKey,string userId,long timestamp ){
      return await _shortUrlService.ShortUrlGenerator("https://www.baidu.com");
     
    }
}

public class CallbackAddress{
    public string AppKey{ get; set; }
}
