// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserLoginInfo.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// 何翔华
// Taf.Core.Net.Identity
// UserLoginInfo.cs

namespace Taf.Core.Net.Identity.Domain.Shared;

using System;

/// <summary>
/// 用户登录接口
/// </summary>
public class UserLoginInfoDto{
    private string _accountName;

    [Required(ErrorMessage = "账号不能为空")]
    public string AccountName{
        get => _accountName;
        set => _accountName = value.Trim().ToUpper();
    }

    private string _password;

    [Required(ErrorMessage = "密码不能为空")]
    public string Password{
        get => _password;
        set => _password = value.Trim();
    }
}
