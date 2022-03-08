// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAuditedObject.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   审核接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

// 何翔华
// Taf.Core.Net.Utility
// IAuditedObject.cs

namespace Taf.Core.Net.Auditing;

/// <summary>
/// This interface can be implemented to add standard auditing properties to a class.
/// </summary>
public interface IAuditedObject : 
    ICreationAuditedObject,
    IModificationAuditedObject,
    IHasModificationTime{
    
}