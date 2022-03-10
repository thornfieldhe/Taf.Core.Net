// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SignClientDto.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//    
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// 何翔华
// Taf.Core.Net.Tools
// SignClientDto.cs

namespace Taf.Core.Net.Tools.Domain.Share;

using System;

/// <summary>
///  签名客户端对象
/// </summary>
public class SignClientDto{
    public Guid Id{ get; set; }
    
    /// <summary>
    /// 客户端Id
    /// </summary>
    [Required]
    [Display(Name = "AppId")]
    public string AppId{ get; set; }

    /// <summary>
    /// 签名密钥
    /// </summary>
    [Display(Name = "AppKey")]
    public string AppKey{ get; set; }

    /// <summary>
    /// 客户名称
    /// </summary>
    [Display(Name = "应用名称")]
    public string Name{ get; set; }
    
    [Display(Name = "创建时间")]
    public DateTime CreationTime{ get; set; }
    
    [Required]
    public string ConcurrencyStamp{ get; set; }
}

