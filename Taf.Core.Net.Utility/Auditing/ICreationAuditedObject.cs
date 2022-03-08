// 何翔华
// Taf.Core.Net.Utility
// ICreationAuditedObject.cs

namespace Taf.Core.Net.Auditing;

/// <summary>
/// This interface can be implemented to store creation information (who and when created).
/// </summary>
public interface ICreationAuditedObject : IHasCreationTime, IMayHaveCreator
{
}
