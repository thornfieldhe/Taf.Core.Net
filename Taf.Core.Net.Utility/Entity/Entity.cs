// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Entity.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Summary
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using MassTransit;
using SqlSugar;
using System.Collections.Generic;
using System.Collections.Immutable;
using Taf.Core.Net.Auditing;
using Taf.Core.Net.Domain.Entities;

// 何翔华
// Taf.Core.Net.Utility
// Entity.cs

namespace Taf.Core.Net.Utility.Entity;

using System;

/// <inheritdoc/>
[Serializable]
public abstract class Entity : IEntity,IHasConcurrencyStamp,IHasAuditedTime
{

    public abstract object[] GetKeys();
    
    /// <summary>
    /// 更新锁,用于确保乐观锁 
    /// </summary>
    [SugarColumn(ColumnName = "concurrency_stamp",IsNullable = false,ColumnDataType = "char(36)")]
    public string ConcurrencyStamp{ get; set; }

    [SugarColumn(ColumnName = "creation_time",IsNullable = false)]
    public DateTime CreationTime{ get; set; }
    
    [SugarColumn(ColumnName = "last_modification_time", IsNullable = true)]
    public DateTime? LastModificationTime{ get; set; }
    
    public override string ToString(){
        var keys = GetKeys();
        Array.Sort(keys);
        return $"[ENTITY:{ string.Join(":", keys)}]";
    }
}

/// <inheritdoc cref="IEntity{TKey}" />
[Serializable]
public abstract class Entity<TKey> : Entity, IEntity<TKey>
{
    [SugarColumn(IsPrimaryKey = true,ColumnName = "id")]
    public virtual TKey Id{ get; protected set; }

    protected Entity()
    {
    }

    protected Entity(TKey id)
    {
        Id = id;
    }

    public override object[] GetKeys()
    {
        return new object[] {Id};
    }

    /// <inheritdoc/>
    public override string ToString() => $"[ENTITY: {GetType().Name}] Id = {Id}";

    public override bool Equals(object? obj){
        var other = obj as Entity<TKey>;
        if (other !=null){
            return Id.Equals(other.Id);
        }

        return false;
    }
}

/// <summary>
/// 实体对象基类
/// </summary>
[Serializable]
public class BaseEntity:Entity<Guid>{
    public BaseEntity(){
        Id = NewId.NextGuid();
    }

    [SugarColumn(IsPrimaryKey = true,ColumnName = "id")]
    public override Guid Id{ get; protected set; }
}