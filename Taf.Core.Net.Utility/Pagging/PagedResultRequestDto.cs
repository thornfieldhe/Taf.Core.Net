// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagedResultRequestDto.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// 何翔华
// Taf.Core.Net.Utility
// PagedResultRequestDto.cs

namespace Taf.Core.Net.Utility.Paging;

/// <summary>
/// 分页查询对象
/// </summary>
public class PagedResultRequestDto: LimitedResultRequestDto, IPagedResultRequest
{
    [Range(0, int.MaxValue)]
    public virtual int PageIndex{ get; set; }
}