// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomException.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

// 何翔华
// Taf.Core.Net.Utility
// CustomException.cs

namespace Taf.Core.Net.Utility.Exception;

using System;

/// <summary>
/// 自定义异常
/// </summary>
public class CustomException : Exception{
    /// <summary>
    /// 异常编码
    /// </summary>
    public Guid Code{ get; set; }

    public string Details{ get; set; }

    public CustomException([NotNull] string message, Guid code, string? details =null) : base(message){
        Code    = Code;
        Details = details;
    }
}