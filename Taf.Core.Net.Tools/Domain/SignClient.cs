// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Client.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Summary
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using SqlSugar;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taf.Core.Net.Utility;

// 何翔华
// EfootprintV3.Database
// Client.cs

namespace Taf.Core.Net.Tools.Domain;

using System;

/// <summary>
/// 客户列表
/// </summary>
[SugarTable("tool_sign_clients",IsDisabledUpdateAll=true)]
public class SignClient : BaseEntity{
    /// <summary>
    /// 客户端Id
    /// </summary>
    [Required]
    [SugarColumn( ColumnName = "app_id", ColumnDataType = "char(36)", IndexGroupNameList = new string[]{ "app_id" })]
    public string AppId{ get; set; }

    /// <summary>
    /// 签名密钥
    /// </summary>
    [SugarColumn( ColumnName = "app_key", ColumnDataType = "nvarchar(50)")]
    [Required]
    public string AppKey{ get; set; }

    /// <summary>
    /// 客户名称
    /// </summary>
    [Required]
    [SugarColumn( ColumnName = "name", ColumnDataType = "nvarchar(50)")]
    public string Name{ get; set; }
}