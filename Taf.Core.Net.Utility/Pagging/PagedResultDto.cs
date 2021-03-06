// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagedResultDto.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Summary
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

// 何翔华
// Taf.Core.Net.Utility
// PagedResultDto.cs

namespace Taf.Core.Net.Utility.Paging;

using System;

/// <summary>
/// Implements <see cref="IPagedResult{T}"/>.
/// </summary>
/// <typeparam name="T">Type of the items in the <see cref="ListResultDto{T}.Items"/> list</typeparam>
[Serializable]
public class PagedResultDto<T> : ListResultDto<T>, IPagedResult<T>
{
    /// <inheritdoc />
    public int TotalCount{ get; set; } //TODO: Can be a long value..?

    /// <summary>
    /// Creates a new <see cref="PagedResultDto{T}"/> object.
    /// </summary>
    public PagedResultDto()
    {

    }

    /// <summary>
    /// Creates a new <see cref="PagedResultDto{T}"/> object.
    /// </summary>
    /// <param name="totalCount">Total count of Items</param>
    /// <param name="items">List of items in current page</param>
    public PagedResultDto(int totalCount, IReadOnlyList<T> items)
        : base(items) =>
        TotalCount = totalCount;
}
