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
    public string OriginalUrl{ get; set; }

    /// <summary>
    /// 短码
    /// </summary>
    public string ShortCode{ get; set; }

    /// <summary>
    /// 过期时间,为空则一直有效
    /// </summary>
    public DateTime? ExpiraionDate{ get; set; }

    /// <summary>
    /// 短链点击次数
    /// </summary>
    public long TotalClickCount{ get; set; }

    public DateTime CreationTime{ get; set; }
}
