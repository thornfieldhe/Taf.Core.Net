// 何翔华
// Taf.Core.Net.Utility
// IMayHaveCreator.cs

namespace Taf.Core.Net.Auditing;

/// <summary>
/// Standard interface for an entity that MAY have a creator.
/// </summary>
public interface IMayHaveCreator
{
    /// <summary>Id of the creator.</summary>
    Guid? CreatorId{ get; }
}
