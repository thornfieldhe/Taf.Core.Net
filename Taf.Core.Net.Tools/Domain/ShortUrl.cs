using SqlSugar;
using Taf.Core.Net.Domain.Entities;
using Taf.Core.Net.Utility.Entity;

namespace Taf.Core.Net.Tools.Domain;

/// <summary>
/// 短链
/// </summary>
[SugarTable("tool_short_urls")]
public class ShortUrl : BaseEntity{
    /// <summary>
    /// 原始地址
    /// </summary>
    [SugarColumn(ColumnName = "original_url", IsNullable = false,ColumnDataType = "nvarchar(2000)")]
    public string OriginalUrl{ get; set; }
    
    /// <summary>
    /// 短码
    /// </summary>
    [SugarColumn(ColumnName = "short_code", IsNullable = false,ColumnDataType = "char(8)",IndexGroupNameList = new string[] { "short_code" })]
    public string    ShortCode      { get; set; }
    
    /// <summary>
    /// 过期时间,为空则一直有效
    /// </summary>
    [SugarColumn(ColumnName = "expiraion_date", IsNullable = true)]
    public DateTime? ExpiraionDate  { get; set; }
    
    /// <summary>
    /// 短链点击次数
    /// </summary>
    [SugarColumn(ColumnName = "total_click_count", IsNullable = false)]
    public long      TotalClickCount{ get; set; }
}
