// 何翔华
// Taf.Core.Net.Blazor.Shared
// ClientAddUiDto.cs

using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace Taf.Core.Net.Blazor.Shared.Data;

public class ClientAddUiDto{
    [Display(Name = "应用名称")]
    public string Name{ get; set; }
}
