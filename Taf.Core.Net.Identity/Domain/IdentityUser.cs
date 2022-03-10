// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdentityUser.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   $Summary$
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using SqlSugar;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taf.Core.Net.Auditing;
using Taf.Core.Net.Domain.Entities;
using Taf.Core.Net.Utility;

// 何翔华
// Taf.Core.Net.Identity
// IdentityUser.cs

namespace Taf.Core.Net.Identity.Domain;

using System;

/// <summary>
/// 用户信息
/// </summary>
[SugarTable("identity_users",IsDisabledUpdateAll=true)]
public class IdentityUser : BaseEntity, IPassivable{
    /// <summary>
    /// 账号
    /// </summary>
    [SugarColumn(ColumnName = "account_name", ColumnDataType = "nvarchar(100)")]
    [Required]
    public string AccountName{ get; set; }

    [SugarColumn(ColumnName = "normalized_account_name",ColumnDataType = "nvarchar(100)")]
    [Required]
    public string NormalizedAccountName{ get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    [SugarColumn(ColumnName = "password", ColumnDataType = "nvarchar(100)")]
    [Required]
    public string Password{ get; set; }

    /// <summary>
    ///     盐值
    /// </summary>
    [SugarColumn(ColumnName = "security_stamp", ColumnDataType = "char(36)")]
    [Required]
    public string SecurityStamp{ get; set; }

    /// <summary>
    /// 用户姓名
    /// </summary>
    [SugarColumn(ColumnName = "userName",ColumnDataType = "nvarchar(100)")]
    [Required]
    public string UserName{ get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    [SugarColumn(ColumnName = "email_address", ColumnDataType = "nvarchar(255)")]
    public string EmailAddress{ get; set; }

    [SugarColumn(ColumnName = "normalized_email_address")]
    public string NormalizedEmailAddress{ get; set; }

    /// <summary>
    /// 邮箱是否已验证
    /// </summary>
    [SugarColumn(ColumnName = "is_email_confirmed")]
    public bool IsEmailConfirmed{ get; set; }

    /// <summary>
    /// 手机号
    /// </summary>
    [SugarColumn(ColumnName = "phone_num",ColumnDataType = "char(20)")]
    public string PhoneNum{ get; set; }

    /// <summary>
    /// 手机号是否已验证
    /// </summary>
    [SugarColumn(ColumnName = "is_phone_num_confirmed")]
    public bool IsPhoneNumConfirmed{ get; set; }

    /// <summary>
    /// 验证码
    /// </summary>
    [SugarColumn(ColumnName = "confirm_code", ColumnDataType = "varchar(6)")]
    public string ConfirmCode{ get; set; }

    /// <summary>
    /// 是否启用双因子验证
    /// </summary>
    [SugarColumn(ColumnName = "is_two_factor_enabled")]
    public bool IsTwoFactorEnabled{ get; set; }

    /// <summary>
    /// 可存放63个权限
    /// </summary>
    [SugarColumn(ColumnName = "permissions")]
    public ulong Permissions{ get; set; }

    /// <summary>
    /// 启用状态
    /// </summary>
    [SugarColumn(ColumnName = "is_active", IsNullable = false)]
    public bool IsActive{ get; set; }
}
