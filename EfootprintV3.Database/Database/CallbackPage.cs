// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CallbackPage.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using SqlSugar;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taf.Core.Net.Utility;

// 何翔华
// EfootprintV3.Database
// CallbackPage.cs

namespace EfootprintV3.Database.Database;

using System;

/// <summary>
/// 回调页面
/// </summary>
[SugarTable("database_callback_pages")]
public class CallbackPage:BaseEntity{
    /// <summary>
    /// 短码
    /// </summary>
    [SugarColumn( ColumnName = "short_code", ColumnDataType = "char(8)", IndexGroupNameList = new string[]{ "short_code" })]
    public string ShortCode{ get; set; }
    
    /// <summary>
    /// 回调页面
    /// </summary>
    [SugarColumn( ColumnName = "callback", ColumnDataType = "nvarchar(1000)")]
    public string Callback { get; set; }
    /// <summary>
    /// 客户端Id
    /// </summary>
    [Required]
    [SugarColumn( ColumnName = "app_id", ColumnDataType = "char(36)", IndexGroupNameList = new string[]{ "app_id" })]
    public string AppId{ get; set; }
        
    [Required]
    [SugarColumn( ColumnName = "user_id", ColumnDataType = "nvarchar(50)", IndexGroupNameList = new string[]{ "user_id" })]
    public string UserId{ get; set; }
}
