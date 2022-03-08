// 何翔华
// Taf.Core.Net.Utility
// IHasModificationTime.cs

namespace Taf.Core.Net.Auditing;

/// <summary>
/// A standard interface to add DeletionTime property to a class.
/// </summary>
public interface IHasModificationTime
{
    /// <summary>
    /// The last modified time for this entity.
    /// </summary>
    DateTime? LastModificationTime{ get; set; }
}
