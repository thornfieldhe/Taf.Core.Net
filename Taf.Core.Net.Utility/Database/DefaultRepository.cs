// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mapster;
using SqlSugar;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Taf.Core.Net.Domain.Entities;
using Taf.Core.Net.Utility.Paging;

// 何翔华
// Taf.Core.Net.Utility
// DefaultRepository.cs

namespace Taf.Core.Net.Utility.Database;

using System;

public interface IRepository<T> where T : BaseEntity, new(){
    ISqlSugarClient GetDbContex();
    Task<T>         FindAsync(Guid                       id);
    Task<int>       CountAsync(Expression<Func<T, bool>> whereExpression);
    Task<bool>      InsertAsync(T                        item);

    Task<bool> UpdateAsync(T item);
    Task<bool> DeleteAsync(T item);

    Task<PagedResultDto<TR>> Page<TR>(PagedAndSortedResultRequestDto query, Expression<Func<T, bool>> whereExpression);
}

/// <summary>
///基础仓储 
/// </summary>
public class Repository<T> : IRepository<T> where T : BaseEntity, new(){
    public readonly ISqlSugarClient _db;

    public Repository(ISqlSugarClient db){
        _db = db;
    }

    public ISqlSugarClient GetDbContex() => _db;

#region query

    public virtual async Task<T> FindAsync(Guid id) => await _db.Queryable<T>().InSingleAsync(id);

    public virtual async Task<PagedResultDto<TR>> Page<TR>(PagedAndSortedResultRequestDto query, Expression<Func<T, bool>> whereExpression){
        RefAsync<int> total = 0;
        var list = (await _db.Queryable<T>().Where(whereExpression).OrderBy(string.IsNullOrEmpty(query.Sorting) ? "id" : query.Sorting)
                             .ToPageListAsync(query.PageIndex, query.PageSize, total))
                  .Select(r => r.Adapt<TR>()).ToList();

        return new PagedResultDto<TR>(total, list);
    }

    public virtual async Task<int> CountAsync(Expression<Func<T, bool>> whereExpression) => await _db.Queryable<T>().CountAsync(whereExpression);

#endregion

#region insert

    public virtual async Task<bool> InsertAsync(T item) => await _db.Insertable<T>(item).ExecuteCommandAsync() == 1;

#endregion

#region update

    public virtual async Task<bool> UpdateAsync(T item){
        var concurrencyStamp = item.ConcurrencyStamp;
        return (await _db.Updateable<T>(item).Where(i => i.Id == item.Id && i.ConcurrencyStamp == concurrencyStamp).ExecuteCommandAsync()) == 1;
    }

#endregion

#region delete

    public virtual async Task<bool> DeleteAsync(T item){
        item.IsDeleted = true;
        var concurrencyStamp = item.ConcurrencyStamp;
        return (await _db.Updateable<T>(item).Where(i => i.Id == item.Id && i.ConcurrencyStamp == concurrencyStamp).UpdateColumns(it => new{ it.IsDeleted })
                         .ExecuteCommandAsync())
            == 1;
    }

#endregion
}
