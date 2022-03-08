// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Permissions.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;

// 何翔华
// Taf.Core.Net.Identity
// Permissions.cs

namespace Taf.Core.Net.Identity.Domain.Shared;

using System;

/// <summary>
/// 权限
/// </summary>
public enum Permissions{
    [Description("超级管理员")] SupperAdmin = 1048576
  , [Description("系统管理员")] Admin       = 32768
  , [Description("默认权限")]  Default     = 1
}
