// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdentityConst.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

// 何翔华
// Taf.Core.Net.Identity
// IdentityConst.cs

namespace Taf.Core.Net.Identity.Domain.Shared;

using System;

/// <summary>
/// 身份常量
/// </summary>
public static class IdentityConst{
    internal const           string AdminName     = "admin@taf.me";
    internal const           string AdminPassword = "2ghlmcl,1HBLSQT.";
    internal const           string AdminSal      = "05411053-EABD-409D-A42F-918595F9D253";
    internal static readonly Guid   AdminId       = new("39fcb899-d059-696d-f54f-96e1f501a1f6");
    internal static readonly int AdminPermissions = (int)Permissions.SupperAdmin
                                                  | (int)Permissions.Admin
                                                  | (int)Permissions.Default;
}
