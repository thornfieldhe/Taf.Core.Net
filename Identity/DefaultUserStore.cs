// 何翔华
// Taf.Cor.Net
// DefaultUserStore.cs

using Microsoft.AspNetCore.Identity;
using SqlSugar.IOC;

namespace Taf.Cor.Net;

public class DefaultUserStore:IUserStore<ApplicationUser>{

    public Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken){
        cancellationToken.ThrowIfCancellationRequested();
        ThrowIfDisposed();
        if (user == null){
            throw new ArgumentNullException(nameof(user));
        }

        return Task.FromResult(user.Id.ToString());
    }

    public Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken){
        cancellationToken.ThrowIfCancellationRequested();
        ThrowIfDisposed();
        if (user == null){
            throw new ArgumentNullException(nameof(user));
        }

        return Task.FromResult(user.Name);
    }

    public async Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken){
        cancellationToken.ThrowIfCancellationRequested();
        ThrowIfDisposed();
        if(user == null){
            throw new ArgumentNullException(nameof(user));
        }
        await DbScoped.SugarScope.Updateable<ApplicationUser>().UpdateColumns(i => new{ Name = userName }).ExecuteCommandHasChangeAsync();
    }

    public Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken){
        cancellationToken.ThrowIfCancellationRequested();
        ThrowIfDisposed();
        if(user == null){
            throw new ArgumentNullException(nameof(user));
        }

        return Task.FromResult(user.NormalizedUserName);
    }

    public Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken){
        cancellationToken.ThrowIfCancellationRequested();
        ThrowIfDisposed();
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }
        user.NormalizedUserName = normalizedName;
        return Task.CompletedTask; 
    }

    public async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken){
        cancellationToken.ThrowIfCancellationRequested();
        ThrowIfDisposed();
        if(user == null){
            throw new ArgumentNullException(nameof(user));
        }

        await DbScoped.SugarScope.Insertable<ApplicationUser>(user).ExecuteCommandAsync();
        return IdentityResult.Success;
    }

    public  async Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken){
        cancellationToken.ThrowIfCancellationRequested();
        ThrowIfDisposed();
        if(user == null){
            throw new ArgumentNullException(nameof(user));
        } 
        await DbScoped.SugarScope.Updateable<ApplicationUser>(user).ExecuteCommandAsync(); 
        return IdentityResult.Success;
    }

    public async Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken){
        cancellationToken.ThrowIfCancellationRequested();
        ThrowIfDisposed();
        if(user == null){
            throw new ArgumentNullException(nameof(user));
        }  
        await DbScoped.SugarScope.Deleteable<ApplicationUser>(user).ExecuteCommandAsync(); 
        return IdentityResult.Success;
    }


    public async Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken){
        cancellationToken.ThrowIfCancellationRequested();
        ThrowIfDisposed();
        if(int.TryParse(userId, out var id)){
            return await DbScoped.SugarScope.Queryable<ApplicationUser>().SingleAsync(r => r.Id == id);
        }

        throw new ArgumentNullException(nameof(userId));
    }

    public async Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken){
        cancellationToken.ThrowIfCancellationRequested();
        ThrowIfDisposed();
        return await DbScoped.SugarScope.Queryable<ApplicationUser>().FirstAsync(r => r.NormalizedUserName == normalizedUserName); 
    }
        
    private bool _disposed;
        
    /// <summary>
    /// Dispose the store
    /// </summary>
    public void Dispose()
    {
        _disposed = true;
    }
    protected void ThrowIfDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(GetType().Name);
        }
    }
}
