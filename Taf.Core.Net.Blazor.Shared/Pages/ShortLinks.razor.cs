// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShortLinks_razor.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Summary
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Taf.Core.Net.Tools.Domain;
using Taf.Core.Net.Tools.Services;
using Taf.Core.Net.Utility.Paging;

// 何翔华
// Taf.Core.Net.Blazor.Shared
// ShortLinks.razor.cs

namespace Taf.Core.Net.Blazor.Shared.Pages;

using System;

/// <summary>
/// Summary
/// </summary>
public partial class ShortLinks: ComponentBase{
    private readonly IShortUrlService _shortUrlService;
    public ShortLinks(IShortUrlService shortUrlService) => _shortUrlService = shortUrlService;

    public Task<PagedResultDto<ShortUrlListDto>> GetAllList(BaseQueryRequestDto query){
        _shortUrlService 
    }
    
    [Inject]
    [NotNull]
    private IStringLocalizer<Foo>? Localizer{ get; set; }
}
