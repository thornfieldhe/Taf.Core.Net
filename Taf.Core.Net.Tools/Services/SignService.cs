// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SignService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mapster;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Taf.Core.Net.Tools.Domain;
using Taf.Core.Net.Tools.Domain.Share;
using Taf.Core.Net.Utility.Database;
using Taf.Core.Net.Utility.Exception;
using Taf.Core.Net.Utility.Paging;
using Taf.Core.Utility;

// 何翔华
// Taf.Core.Net.Tools
// SignService.cs

namespace Taf.Core.Net.Tools.Services;

using System;

/// <summary>
/// 签名服务
/// </summary>
public class SignService : ISignService{
    private readonly IRepository<SignClient> _signClientRepository;
    private readonly IRepository<SignUser>   _signUserRepository;

    public SignService(
        IRepository<SignClient> signClientRepository
      , IRepository<SignUser>   signUserRepository){
        _signClientRepository = signClientRepository;
        _signUserRepository   = signUserRepository;
    }

    public async Task<bool> SignGenerator([NotNull] string name) =>
        await _signClientRepository.InsertAsync(new SignClient(){ Name = name.Trim(), AppId = Guid.NewGuid().ToString().Replace("-", ""), AppKey = Randoms.GetRandomCode(12) });

    public async Task<bool> SaveClient(SignClientDto item) =>
        await _signClientRepository.UpdateAsync(new SignClient(){ Name = item.Name, Id = item.Id, ConcurrencyStamp = item.ConcurrencyStamp });

    public async Task<PagedResultDto<SignUserDto>> GetAllUserList(BaseQueryRequestDto query) => await _signUserRepository.Page<SignUserDto>(query, (s) => string.IsNullOrEmpty(query.KeyWord)
     || s.AppId==query.KeyWord.Trim());

    public async Task<PagedResultDto<SignClientDto>> GetAllList(BaseQueryRequestDto query){
        return await _signClientRepository.Page<SignClientDto>(query, (s) => string.IsNullOrEmpty(query.KeyWord)
                                                                          || s.Name.Contains(query.KeyWord)
                                                                          || s.AppId.Contains(query.KeyWord));
    }

    public async Task<string?> GetAppKeyById([NotNull] string appId){
        return (await _signClientRepository.FirstOrDefaultAsync(r => r.AppId == appId.Trim()))?.AppKey;
    }

    public async Task<bool> CreateUser([NotNull] string appId, [NotNull] string userId){
        if((await _signUserRepository.CountAsync(r => r.AppId == appId.Trim() && r.UserId == userId.Trim())) == 0){
            return await _signUserRepository.InsertAsync(new SignUser(){ AppId = appId, UserId = userId });
        }

        return true;
    }

    public async Task<bool> DeleteUser(SignUserDto user) => await _signUserRepository.DeleteAsync(new SignUser(){ Id = user.Id, ConcurrencyStamp = user.ConcurrencyStamp });
    public async Task DeleteAllUsers([NotNull]string appId) => await _signUserRepository.DeleteAllAsync(r=>r.AppId==appId.Trim());

    public async Task<bool> Delete(SignClientDto dto) => await _signClientRepository.DeleteAsync(new SignClient(){ Id = dto.Id, ConcurrencyStamp = dto.ConcurrencyStamp });
}
