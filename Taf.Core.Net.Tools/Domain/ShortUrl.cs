using SqlSugar;
using System.ComponentModel.DataAnnotations;
using Taf.Core.Net.Domain.Entities;
using Taf.Core.Net.Utility;
using Taf.Core.Utility;

namespace Taf.Core.Net.Tools.Domain;

/// <summary>
/// 短链
/// </summary>
[SugarTable("tool_short_urls",IsDisabledUpdateAll=true)]
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
    
    private string _targeturl;
    /// <summary>
    /// 目标地址
    /// </summary>
    [SugarColumn(ColumnName = "target_url", ColumnDataType = "nvarchar(2000)")]
    [Required]
    public string Targeturl{
        get => _targeturl;
        set{
            NormalizedTargeturl = value.ToUpper();
            _targeturl          = value;
        }
    }
    
    [SugarColumn(ColumnName = "normalized_target_url",ColumnDataType = "nvarchar(2000)")]
    [Required]
    public string NormalizedTargeturl{ get; set; }

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
    public DateTime? ExpirationDate{ get; set; }

    /// <summary>
    /// 短链点击次数
    /// </summary>
    [SugarColumn(ColumnName = "total_click_count")]
    public long TotalClickCount{ get; set; }
    
    /// <summary>
    /// 数据来源
    /// </summary>
    [SugarColumn(ColumnName = "source",ColumnDataType = "nvarchar(36)")]
    public string Source{ get; set; }
    
    /// <summary>
    /// 回调地址
    /// </summary>
    [SugarColumn(ColumnName = "callback",ColumnDataType = "nvarchar(1000)")]
    public string CallBack{ get; set; }
}
