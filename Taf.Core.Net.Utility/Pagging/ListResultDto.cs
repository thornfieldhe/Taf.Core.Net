// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListResultDto.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Summary
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

// 何翔华
// Taf.Core.Net.Utility
// ListResultDto.cs

namespace Taf.Core.Net.Utility.Paging;

using System;

[Serializable]
public class ListResultDto<T> : IListResult<T>
{
    /// <inheritdoc />
    public IReadOnlyList<T> Items
    {
        get { return _items ?? (_items = new List<T>()); }
        set { _items = value; }
    }
    private IReadOnlyList<T> _items;

    /// <summary>
    /// Creates a new <see cref="ListResultDto{T}"/> object.
    /// </summary>
    public ListResultDto()
    {
            
    }

    /// <summary>
    /// Creates a new <see cref="ListResultDto{T}"/> object.
    /// </summary>
    /// <param name="items">List of items</param>
    public ListResultDto(IReadOnlyList<T> items)
    {
        Items = items;
    }
}
