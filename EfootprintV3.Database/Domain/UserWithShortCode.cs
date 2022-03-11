// 何翔华
// Taf.Core.Net.Tools
// SignUser.cs

using SqlSugar;
using System.ComponentModel.DataAnnotations;
using Taf.Core.Net.Utility;

namespace EfootprintV3.Database.Domain;

/// <summary>
/// 用户短链关系表
/// </summary>
[SugarTable("business_user_short_codes",IsDisabledUpdateAll=true)]
public class UserWithShortCode :BaseEntity{
    /// <summary>
    /// 应用Id
    /// </summary>
    [Required]
    [SugarColumn( ColumnName = "app_id", ColumnDataType = "char(36)", IndexGroupNameList = new string[]{ "app_id" })]
    public string AppId{ get; set; }
    
    [Required]
    [SugarColumn( ColumnName = "user_id", ColumnDataType = "nvarchar(50)", IndexGroupNameList = new string[]{ "user_id" })]
    public string UserId{ get; set; }
    
    [Required]
    [SugarColumn( ColumnName = "short_code", ColumnDataType = "char(8)", IndexGroupNameList = new string[]{ "short_code" })]
    public string ShortCode{ get; set; }
    
    /// <summary>
    /// 过期时间,为空则一直有效
    /// </summary>
    [SugarColumn(ColumnName = "expiraion_date")]
    public DateTime? ExpirationDate{ get; set; }
}
