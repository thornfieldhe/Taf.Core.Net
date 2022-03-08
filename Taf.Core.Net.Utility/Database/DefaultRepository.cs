// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using SqlSugar;
using System.Collections.Generic;
using System.Linq.Expressions;
using Taf.Core.Net.Domain.Entities;

// 何翔华
// Taf.Core.Net.Utility
// DefaultRepository.cs

namespace Taf.Core.Net.Utility.Database;

using System;

public interface IRepository<T, TK> where T : class, IEntity<TK>, new(){
    ISqlSugarClient GetDbContex();
    Task<T>         FindAsync(TK                         id);
    Task<int>       CountAsync(Expression<Func<T, bool>> whereExpression);
    Task<bool>      InsertAsync(T                        item);
}

/// <summary>
///基础仓储 
/// </summary>
public class Repository<T, TK> : IRepository<T, TK> where T : class, IEntity<TK>, new(){
    private readonly ISqlSugarClient _db;

    public Repository(ISqlSugarClient db) => _db = db;

    public ISqlSugarClient GetDbContex() => _db;

    public async Task<T> FindAsync(TK id) => await _db.Queryable<T>().InSingleAsync(id);

    public async Task<int> CountAsync(Expression<Func<T, bool>> whereExpression) => await _db.Queryable<T>().CountAsync(whereExpression);

    public async Task<bool> InsertAsync(T item) => await _db.Insertable<T>(item).ExecuteCommandAsync()==1;

}





