// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LimitedResultRequestDto.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//  简单查询对象 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taf.Core.Net.Utility.Localization;

// 何翔华
// Taf.Core.Net.Utility
// LimitedResultRequestDto.cs

namespace Taf.Core.Net.Utility.Paging;

using System;

/// <summary>
/// 简单查询对象
/// </summary>
[Serializable]
public class LimitedResultRequestDto : ILimitedResultRequest, IValidatableObject
{
    /// <summary>
    /// Default value: 10.
    /// </summary>
    public static int DefaultMaxResultCount{ get; set; } = 20;

    /// <summary>
    /// Maximum possible value of the <see cref="PageSize"/>.
    /// Default value: 1,000.
    /// </summary>
    public static int MaxMaxResultCount{ get; set; } = 1000;

    /// <summary>
    /// Maximum result count should be returned.
    /// This is generally used to limit result count on paging.
    /// </summary>
    [Range(1, int.MaxValue)]
    public virtual int PageSize{ get; set; } = DefaultMaxResultCount;

    public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (PageSize > MaxMaxResultCount)
        {
            var localizer = validationContext.GetRequiredService<IStringLocalizer<ApplicationContractsResource>>();

            yield return new ValidationResult(
                localizer[
                    "MaxResultCountExceededExceptionMessage", 
                    nameof(PageSize),
                    MaxMaxResultCount, 
                    typeof(LimitedResultRequestDto).FullName, 
                    nameof(MaxMaxResultCount)
                ],
                new[] { nameof(PageSize) });
        }
    }
}