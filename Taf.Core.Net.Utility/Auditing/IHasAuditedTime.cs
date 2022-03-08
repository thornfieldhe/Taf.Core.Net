// 何翔华
// Taf.Core.Net.Utility
// IHasAuditedTime.cs

namespace Taf.Core.Net.Auditing;

/// <summary>
///This interface can be implemented to store created time and modified time. 
/// </summary>
public interface IHasAuditedTime:IHasCreationTime,IHasModificationTime{
    
}
