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
using System.ComponentModel.DataAnnotations;
using Taf.Core.Net.Domain.Entities;
using Taf.Core.Net.Utility;

// 何翔华
// Taf.Core.Net.Identity
// IdentityRole.cs

namespace Taf.Core.Net.Identity.Domain;

using System;

/// <summary>
/// 角色
/// </summary>
[SugarTable("identity_roles",IsDisabledUpdateAll=true)]
public class IdentityRole : BaseEntity{
    
    /// <summary>
    /// 角色名称
    /// </summary>
    [SugarColumn(ColumnName = "name",ColumnDataType = "nvarchar(50)")] 
    [Required]
    public string Name{ get; set; }
   
    /// <summary>
    /// 角色显示名称
    /// </summary>
    [SugarColumn(ColumnName = "display_name", ColumnDataType = "nvarchar(50)")] 
    [Required]
    public string DisplayName{ get; set; } 

    
    [SugarColumn(ColumnName = "permissions")]
    public ulong Permissions{ get; set; }
}
