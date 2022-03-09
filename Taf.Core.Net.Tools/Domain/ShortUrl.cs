using SqlSugar;
using System.ComponentModel.DataAnnotations;
using Taf.Core.Net.Domain.Entities;
using Taf.Core.Net.Utility.Entity;
using Taf.Core.Utility;

namespace Taf.Core.Net.Tools.Domain;

/// <summary>
/// 短链
/// </summary>
[SugarTable("tool_short_urls")]
public class ShortUrl : BaseEntity{

    private string _originalUrl;
    /// <summary>
    /// 原始地址
    /// </summary>
    [SugarColumn(ColumnName = "original_url", ColumnDataType = "nvarchar(2000)")]
    [Required]
    public string OriginalUrl{
        get => _originalUrl;
        set{
            NormalizedOriginalUrl = value.ToUpper();
            _originalUrl          = value;
        }
    }
    
    [SugarColumn(ColumnName = "normalized_original_url",ColumnDataType = "nvarchar(2000)")]
    [Required]
    public string NormalizedOriginalUrl{ get; set; }

    /// <summary>
    /// 短码
    /// </summary>
    [SugarColumn(ColumnName = "short_code",  ColumnDataType = "char(8)", IndexGroupNameList = new string[]{ "short_code" })]
    [Required]
    public string ShortCode{ get; set; }

    /// <summary>
    /// 过期时间,为空则一直有效
    /// </summary>
    [SugarColumn(ColumnName = "expiraion_date")]
    public DateTime? ExpiraionDate{ get; set; }

    /// <summary>
    /// 短链点击次数
    /// </summary>
    [SugarColumn(ColumnName = "total_click_count")]
    public long TotalClickCount{ get; set; }
}
