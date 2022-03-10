// 何翔华
// Taf.Core.Net.Tools
// SignUserDto.cs

using System.ComponentModel.DataAnnotations;

namespace Taf.Core.Net.Tools.Domain.Share;

public class SignUserDto{
    public Guid Id{ get; set; }
    
    /// <summary>
    /// 应用Id
    /// </summary>
    [Display(Name = "AppId")]
    public string AppId{ get; set; }
    
    [Display(Name = "用户Id")]
    public string UserId{ get; set; }
    
    /// <summary>
    /// 备注
    /// </summary>
    [Display(Name = "备注")] 
    public string Note{ get; set; }
        
    [Display(Name = "创建时间")]
    public DateTime CreationTime{ get; set; }
    
    [Required]
    public string ConcurrencyStamp{ get; set; }
}
