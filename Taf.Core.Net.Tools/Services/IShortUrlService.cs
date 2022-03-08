// 何翔华
// Taf.Core.Net.Tools
// IShortUrlService.cs

namespace Taf.Core.Net.Tools.Services;

public interface IShortUrlService{
    Task<string> ShortUrlGenerator(string url, DateTime? expiraionDate = null);
}
