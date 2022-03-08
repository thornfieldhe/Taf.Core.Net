// 何翔华
// Taf.Core.Net.Web
// Home.cs

using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using Taf.Core.Net.Tools.Services;

namespace Taf.Core.Net.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase{
    private readonly IShortUrlService _shortUrlService;

    // GET
    public HomeController( IShortUrlService shortUrlService){
        _shortUrlService = shortUrlService;
    }

    [HttpGet]
    public async Task<string> Test(){
      return await _shortUrlService.ShortUrlGenerator("www.baidu.com");
     
    }
}
