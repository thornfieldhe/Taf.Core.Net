// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntity.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   实体对象接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Taf.Core.Net.Auditing;

// 何翔华
// Taf.Core.Net.Utility
// IEntity.cs

namespace Taf.Core.Net.Domain.Entities;

/// <summary>
/// Defines an entity with a single primary key with "Id" property.
/// </summary>
/// <typeparam name="TKey">Type of the primary key of the entity</typeparam>
public interface IEntity<TKey> : IEntity
{
    /// <summary>Unique identifier for this entity.</summary>
    TKey Id{ get; }
}

/// <summary>
/// Defines an entity. It's primary key may not be "Id" or it may have a composite primary key.
/// Use <see cref="T:Volo.Abp.Domain.Entities.IEntity`1" /> where possible for better integration to repositories and other structures in the framework.
/// </summary>
public interface IEntity:IHasConcurrencyStamp,IHasAuditedTime
{
    /// <summary>Returns an array of ordered keys for this entity.</summary>
    /// <returns></returns>
    object[] GetKeys();
}