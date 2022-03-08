// 何翔华
// Taf.Core.Net.Utility
// ISortedResultRequest.cs

namespace Taf.Core.Net.Utility.Paging;

/// <summary>
/// This interface is defined to standardize to request a sorted result.
/// </summary>
public interface ISortedResultRequest
{
    /// <summary>
    /// Sorting information.
    /// Should include sorting field and optionally a direction (ASC or DESC)
    /// Can contain more than one field separated by comma (,).
    /// </summary>
    /// <example>
    /// Examples:
    /// "Name"
    /// "Name DESC"
    /// "Name ASC, Age DESC"
    /// </example>
    string Sorting{ get; set; }
}
