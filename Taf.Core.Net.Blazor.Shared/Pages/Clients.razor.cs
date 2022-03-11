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
    /// 
    /// </summary>
    private static IEnumerable<int> PageItemsSource => new int[]{ 20, 40 };

    private Task<PagedResultDto<SignClientDto>> GetAllList(string key = null) => SignService.GetAllList(new BaseQueryRequestDto(){ KeyWord = key });

    private async Task<PagedResultDto<SignClientDto>> QueryAll(string keyWord, string shorting, int index) =>
        await SignService.GetAllList(new BaseQueryRequestDto(){ KeyWord = keyWord, Sorting = shorting, PageIndex = index });

    private async Task<QueryData<SignClientDto>> OnSearchQueryAsync(QueryPageOptions options){
        var list = await QueryAll(options.SearchText, options.SortName, options.PageIndex);

        // 设置记录总数
        var total = list.TotalCount;
        return new QueryData<SignClientDto>(){
            Items      = list.Items
          , TotalCount = list.TotalCount
          , IsSorted   = true
          , IsFiltered = true
          , IsSearch   = true
        };
    }

    private async Task<bool> OnDeleteAsync(IEnumerable<SignClientDto> arg){
        foreach(var item in arg){
            await SignService.Delete(new SignClientDto(){ Id = item.Id, ConcurrencyStamp = item.ConcurrencyStamp });
            await SignService.DeleteAllUsers(item.AppId.Replace("-",""));
        }

        return true;
    }

    private Task<SignClientDto> OnAddAsync() => Task.FromResult(new SignClientDto());

    private async Task<bool> OnSaveAsync(SignClientDto item, ItemChangedType changedType){
        if(changedType == ItemChangedType.Add){
            return await SignService.SignGenerator(item.Name);
        }

        return false;
    }
}
