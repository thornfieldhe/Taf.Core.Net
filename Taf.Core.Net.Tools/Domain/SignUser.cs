// 何翔华
// Taf.Core.Net.Tools
// SignUser.cs

using SqlSugar;
using System.ComponentModel.DataAnnotations;
using Taf.Core.Net.Utility;

namespace Taf.Core.Net.Tools.Domain;

/// <summary>
/// 签名用户
/// </summary>
[SugarTable("tool_sign_users",IsDisabledUpdateAll=true)]
public class SignUser :BaseEntity{
    /// <summary>
    /// 客户端Id
    /// </summary>
    [Required]
    [SugarColumn(IsPrimaryKey = true, ColumnName = "app_id", ColumnDataType = "char(36)", IndexGroupNameList = new string[]{ "app_id" })]
    public Guid AppId{ get; set; }
    
    [Required]
    [SugarColumn( ColumnName = "user_id", ColumnDataType = "nvarchar(50)")]
    public string UserId{ get; set; }
    
    /// <summary>
    /// 备注
    /// </summary>
    [SugarColumn(ColumnName = "note", ColumnDataType = "nvarchar(200)")]
    public string Note{ get; set; }
}
