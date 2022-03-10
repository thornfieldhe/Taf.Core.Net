// 何翔华
// Taf.Core.Net.Web
// ShorUrlCreateDto.cs

using System.ComponentModel.DataAnnotations;
using Taf.Core.Net.Tools.Domain.Share;

namespace Taf.Core.Net.Tools.Domain.Share;

/// <summary>
/// 短链创建对象
/// </summary>
public class ShorUrlCreateDto{
    [Required]
    public string AppId{ get; set; }

    public string? UserId{ get; set; }

    /// <summary>
    /// 应用来源
    /// </summary>
    public SignClientSource Source{ get; set; }

    /// <summary>
    /// 源Url地址
    /// </summary>
    [Required]
    public string SourceUrl{ get; set; }

    /// <summary>
    /// 目标Url地址
    /// </summary>
    [Required]
    public string TargetUrl{ get; set; }

    /// <summary>
    /// 回调地址
    /// </summary>
    public string? Callback{ get; set; }
    
    public DateTime? ExpiraionDate{ get; set; }
}