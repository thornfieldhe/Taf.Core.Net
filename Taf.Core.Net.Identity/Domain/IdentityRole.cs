// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdentityRole.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using SqlSugar;
using System.Collections.Generic;
using Taf.Core.Net.Domain.Entities;
using Taf.Core.Net.Utility.Entity;

// 何翔华
// Taf.Core.Net.Identity
// IdentityRole.cs

namespace Taf.Core.Net.Identity.Domain;

using System;

/// <summary>
/// 角色
/// </summary>
[SugarTable("identity_roles")]
public class IdentityRole : BaseEntity,  ISoftDelete{
    
    /// <summary>
    /// 角色名称
    /// </summary>
    [SugarColumn(ColumnName = "name", IsNullable = false,ColumnDataType = "nvarchar(50)")] 
    public string Name{ get; set; }
   
    /// <summary>
    /// 角色显示名称
    /// </summary>
    [SugarColumn(ColumnName = "display_name", IsNullable = false,ColumnDataType = "nvarchar(50)")] 
    public string DisplayName{ get; set; } 
    
    [SugarColumn(ColumnName = "is_deleted", IsNullable = false)]
    public bool IsDeleted{ get; set; }
    
    [SugarColumn(ColumnName = "permissions")]
    public ulong Permissions{ get; set; }
}
