// 何翔华
// Taf.Core.Net.Blazor.Shared
// ClientAddUiDto.cs

using System.ComponentModel.DataAnnotations;

namespace Taf.Core.Net.Tools.Domain.Share;

public class ClientAddDto{
    [Display(Name = "应用名称")]
    public string Name{ get; set; }
}
