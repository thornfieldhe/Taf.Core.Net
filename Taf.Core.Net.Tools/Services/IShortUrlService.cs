// 何翔华
// Taf.Core.Net.Tools
// IShortUrlService.cs

using Taf.Core.Net.Tools.Domain;
using Taf.Core.Net.Tools.Domain.Share;
using Taf.Core.Net.Utility.Paging;

namespace Taf.Core.Net.Tools.Services;

public interface IShortUrlService{
    Task<string> ShortUrlGenerator(ShorUrlCreateDto input);

    Task<PagedResultDto<ShortUrlListDto>> GetAllList(BaseQueryRequestDto query);
}
