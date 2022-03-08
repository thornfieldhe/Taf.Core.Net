// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISoftDelete.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   $Summary$
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

// 何翔华
// Taf.Core.Net.Utility
// ISoftDelete.cs

namespace Taf.Core.Net.Domain.Entities;

using System;

/// <summary>
/// 软删除接口 
/// </summary>
public interface ISoftDelete{
    bool IsDeleted{ get; set; }
}
