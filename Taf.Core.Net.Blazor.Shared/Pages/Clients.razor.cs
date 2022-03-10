// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShortLinks_razor.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Summary
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Taf.Core.Net.Blazor.Shared.Data;
using Taf.Core.Net.Tools.Domain;
using Taf.Core.Net.Tools.Domain.Share;
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
public partial class Clients{
    [Inject]
    public ISignService SignService{ get; set; }

    /// <summary>
    /// 获得 弹窗注入服务
    /// </summary>
    [Inject]
    [NotNull]
    private DialogService? DialogService{ get; set; }

    private ClientAddUiDto Model{ get; set; } = new();

    /// <summary>
    /// 
    /// </summary>
    private static IEnumerable<int> PageItemsSource => new int[]{ 20, 40 };

    private List<SignClientDto>                 Items                         { get; set; }
    private Task<PagedResultDto<SignClientDto>> GetAllList(string key = null) => SignService.GetAllList(new BaseQueryRequestDto(){ KeyWord = key });

    /// <summary>
    /// OnInitialized 方法
    /// </summary>
    protected override void OnInitialized(){
        base.OnInitialized();
        Items = QueryAll(null, null, 1).Result.Items.ToList();
    }

    private async Task<PagedResultDto<SignClientDto>> QueryAll(string keyWord, string shorting, int index) =>
        await SignService.GetAllList(new BaseQueryRequestDto(){ KeyWord = keyWord, Sorting = shorting, PageIndex = index });

    private async Task<QueryData<SignClientDto>> OnSearchQueryAsync(QueryPageOptions options){
        var list = await QueryAll(options.SearchText, options.SortName, options.PageIndex);

        // 设置记录总数
        var total = list.TotalCount;
        Items = list.Items.ToList();
        return new QueryData<SignClientDto>(){
            Items      = Items
          , TotalCount = list.TotalCount
          , IsSorted   = true
          , IsFiltered = true
          , IsSearch   = true
        };
    }

    private async Task ShowAddDialogAsync(){
        var option = new EditDialogOption<ClientAddUiDto>(){
            Title       = "新增应用"
          , Model       = Model
          , RowType     = RowType.Inline
          , Size        = Size.Small
          , OnEditAsync = async (context) => {
                var result= await SignService.SignGenerator(Model.Name);
                Items = QueryAll(null, null, 1).Result.Items.ToList();
                return result;
            }
        };
        await DialogService.ShowEditDialog(option);
     
    }
}
