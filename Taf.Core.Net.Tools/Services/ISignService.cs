// 何翔华
// Taf.Core.Net.Tools
// ISignService.cs

using System.Diagnostics.CodeAnalysis;
using Taf.Core.Net.Tools.Domain.Share;
using Taf.Core.Net.Utility.Paging;

namespace Taf.Core.Net.Tools.Services;

public interface ISignService{
    Task<bool>   SignGenerator([NotNull] string name);
    Task<bool>   SaveClient(SignClientDto       item);
    Task<bool>   Delete(SignClientDto           dto);
    Task<string> GetAppKeyById([NotNull] string appId);

    Task<bool> CreateUser(string appId, string userId);

    Task<bool> DeleteUser(SignUserDto user);
    Task DeleteAllUsers(string appId);

    Task<PagedResultDto<SignUserDto>> GetAllUserList(BaseQueryRequestDto query);

    Task<PagedResultDto<SignClientDto>> GetAllList(BaseQueryRequestDto query);
}
