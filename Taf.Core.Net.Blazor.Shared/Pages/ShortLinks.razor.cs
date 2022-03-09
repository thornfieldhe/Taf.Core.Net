// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ShortLinks_razor.cs" company="" author="何翔华">
// //   
// // </copyright>
// // <summary>
// //   Summary
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
//
// using BootstrapBlazor.Components;
// using Microsoft.AspNetCore.Components;
// using System.Collections.Generic;
// using System.Diagnostics.CodeAnalysis;
// using Taf.Core.Net.Tools.Domain;
// using Taf.Core.Net.Tools.Services;
// using Taf.Core.Net.Utility.Paging;
//
// // 何翔华
// // Taf.Core.Net.Blazor.Shared
// // ShortLinks.razor.cs
//
// namespace Taf.Core.Net.Blazor.Shared.Pages;
//
// using System;
//
// /// <summary>
// /// Summary
// /// </summary>
// public partial class ShortLinks : ComponentBase{
//     private readonly IShortUrlService _shortUrlService;
//     public ShortLinks(IShortUrlService shortUrlService) => _shortUrlService = shortUrlService;
//
//     /// <summary>
//     /// 
//     /// </summary>
//     private static IEnumerable<int> PageItemsSource => new int[] { 20, 40 };
//     
//     private List<ShortUrlListDto>                 Items                         { get; set; }
//     private Task<PagedResultDto<ShortUrlListDto>> GetAllList(string key = null) => _shortUrlService.GetAllList(new BaseQueryRequestDto(){ KeyWord = key });
//
//     /// <summary>
//     /// OnInitialized 方法
//     /// </summary>
//     protected override void OnInitialized()
//     {
//         base.OnInitialized();
//         Items = QueryAll(null, null, 1).Result.Items.ToList();
//     }
//     
//   private  async Task<PagedResultDto<ShortUrlListDto>> QueryAll(string keyWord, string shorting, int index) =>
//       await _shortUrlService.GetAllList(new BaseQueryRequestDto(){
//           KeyWord = keyWord, Sorting = shorting, PageIndex = index
//       });
//
//   private async Task<QueryData<ShortUrlListDto>> OnSearchQueryAsync(QueryPageOptions options){
//       var list =await QueryAll(options.SearchText, options.SortName, options.PageIndex);
//
//         // 设置记录总数
//         var total = list.TotalCount;
//
//         return new QueryData<ShortUrlListDto>(){
//             Items      = list.Items
//           , TotalCount = list.TotalCount
//           , IsSorted   = true
//           , IsFiltered = true
//           , IsSearch   = true
//         };
//     }
// }
