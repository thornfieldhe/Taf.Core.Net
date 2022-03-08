// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocalizationResourceNameAttribute.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Summary
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

// 何翔华
// Taf.Core.Net.Utility
// LocalizationResourceNameAttribute.cs

namespace Taf.Core.Net.Utility.Localization;

using System;

public class LocalizationResourceNameAttribute : Attribute
{
    public string Name{ get; }

    public LocalizationResourceNameAttribute(string name)
    {
        Name = name;
    }

    public static LocalizationResourceNameAttribute GetOrNull(Type resourceType)
    {
        return resourceType
              .GetCustomAttributes(true)
              .OfType<LocalizationResourceNameAttribute>()
              .FirstOrDefault();
    }

    public static string GetName(Type resourceType)
    {
        return GetOrNull(resourceType)?.Name ?? resourceType.FullName;
    }
}
