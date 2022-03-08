// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainLayout_razor.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Summary
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System.Diagnostics.CodeAnalysis;


// 何翔华
// Taf.Core.Net.Web
// MainLayout.razor.cs

namespace Taf.Core.Net.Web.Shared;

using System;

/// <summary>
/// Summary
/// </summary>
public partial class MainLayout{
    [NotNull]
    private IEnumerable<MenuItem>? IconSideMenuItems{ get; set; } 
    /// <summary>
    /// OnInitialized 方法
    /// </summary>
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        IconSideMenuItems = await MenusDataGerator.GetIconSideMenuItemsAsync(Localizer);

    }
    
    [Inject]
    [NotNull]
    private IStringLocalizer<NavMenu>? Localizer{ get; set; }
}
