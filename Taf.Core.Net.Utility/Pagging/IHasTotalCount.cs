// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CLASS.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Summary
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

// 何翔华
// Taf.Core.Net.Utility
// IHasTotalCount.cs

namespace Taf.Core.Net.Utility.Paging;

/// <summary>
/// This interface is defined to standardize to set "Total Count of Items" to a DTO.
/// </summary>
public interface IHasTotalCount
{
    /// <summary>
    /// Total count of Items.
    /// </summary>
    int TotalCount{ get; set; }
}