using SqlSugar;
using System.ComponentModel.DataAnnotations;
using Taf.Core.Net.Domain.Entities;
using Taf.Core.Net.Utility;
using Taf.Core.Utility;

namespace Taf.Core.Net.Tools.Domain.Share;

/// <summary>
/// 短链
/// </summary>
public record ShortUrlListDto{
    public Guid Id{ get; set; }

    /// <summary>
    /// 原始地址
    /// </summary>
    [Display(Name = "原始地址")]
    [Required]
    public string OriginalUrl{ get; set; }

    /// <summary>
    /// 短码
    /// </summary>
    [Display(Name = "短码")]
    public string ShortCode{ get; set; }

    /// <summary>
    /// 过期时间,为空则一直有效
    /// </summary>
    [Display(Name = "过期时间")]
    public DateTime? ExpiraionDate{ get; set; }

    /// <summary>
    /// 短链点击次数
    /// </summary>
    [Display(Name = "短链点击次数")]
    public long TotalClickCount{ get; set; }

    [Display(Name = "创建时间")]
    public DateTime CreationTime{ get; set; }
            
    /// <summary>
    /// 数据来源
    /// </summary>
    [Display(Name = "数据来源")]
    [Required]
    public string Source{ get; set; }
}
