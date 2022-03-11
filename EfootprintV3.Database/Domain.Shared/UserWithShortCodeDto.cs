// 何翔华
// Taf.Core.Net.Tools
// SignUser.cs

using SqlSugar;
using System.ComponentModel.DataAnnotations;
using Taf.Core.Net.Utility;

namespace EfootprintV3.Database.Domain.Share;

/// <summary>
/// 用户短链关系表
/// </summary>
public class UserWithShortCodeDto{
    /// <summary>
    /// 应用Id
    /// </summary> 
    [Required]
    public string AppId{ get; set; }
    
    [Required]
    public string UserId{ get; set; }
    
    [Required]
    public string ShortCode{ get; set; }
    
    /// <summary>
    /// 过期时间,为空则一直有效
    /// </summary>
    [SugarColumn(ColumnName = "expiraion_date")]
    public DateTime? ExpirationDate{ get; set; }
    
    /// <summary>
    /// Creation time.
    /// </summary>
   public DateTime CreationTime{ get; set; }
}
