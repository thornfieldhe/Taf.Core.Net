// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using MassTransit;
using SqlSugar;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taf.Core.Net.Identity.Domain;
using Taf.Core.Net.Identity.Domain.Shared;
using Taf.Core.Net.Utility.Cache;
using Taf.Core.Utility;

// 何翔华
// Taf.Core.Net.Identity
// UserService.cs

namespace Taf.Core.Net.Identity.Services;

using System;

/// <summary>
/// 用户服务 
/// </summary>
public class UserService{
    private readonly ISimpleClient<IdentityUser> _userClient;

    public UserService(ISimpleClient<IdentityUser> userClient){
        _userClient = userClient;
    }

    /// <summary>
    ///     登录
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<UserDto> Login(UserLoginInfoDto dto){
        var user = new UserDto();
        if(AdminLoginSuccess(dto, user)){
            return Task.FromResult(user);
        }

        throw new Utility.Exception.ValidationException("用户名或密码错误", new List<ValidationResult>(){ new("用户名或密码错误", new[]{ "UserName", "Password" }) });
    }

    private bool AdminLoginSuccess(UserLoginInfoDto dto, UserDto user){
        if(dto.AccountName == IdentityConst.AdminName
        && ValidatePassword(dto.Password, IdentityConst.AdminSal, IdentityConst.AdminPassword)){
            user.Id           = IdentityConst.AdminId;
            user.Permissions  = IdentityConst.AdminPermissions;
            user.EmailAddress = dto.AccountName;
            user.UserName     = "超级管理员";
            CreateToken(user);
            // 将当前用户添加到缓存
            StaticRedisClient.Instance.Client.Set(user.AccountName, user
                                                , StaticRedisClient.Instance.Expiry);
            return true;
        }

        return false;
    }


    private string CreateToken(UserDto user){
        var payload = new Dictionary<string, object>{
            { "userName", user.UserName }
           ,{ "permissions", user.Permissions }
           ,{ "phoneNum", user.PhoneNum }
           ,{ "emailAddress", user.EmailAddress }
           ,{ "accountName", user.AccountName }
           ,{ "exp", DateTimeOffset.Now.AddHours(1).ToUnixTimeSeconds() }
           ,{ "iss", "thornfield" }
        };
        const string secret     = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";
        var          algorithm  = new HMACSHA256Algorithm(); // symmetric
        var          serializer = new JsonNetSerializer();
        var          urlEncoder = new JwtBase64UrlEncoder();
        var          encoder    = new JwtEncoder(algorithm, serializer, urlEncoder);
        user.Token = encoder.Encode(payload, secret);
        return user.Token;
    }

    /// <summary>
    /// </summary>
    /// <param name="password"></param>
    /// <param name="sal"></param>
    /// <param name="newPassword"></param>
    /// <returns></returns>
    private bool ValidatePassword(string password, string sal, string newPassword) => Encrypt.GetMd5Hash($"{password}-{sal}") == newPassword;
}

public class UserDto{
    public Guid   Id          { get; set; }
    public string AccountName { get; set; }
    public string UserName    { get; set; }
    public string EmailAddress{ get; set; }
    public string PhoneNum    { get; set; }
    public long   Permissions { get; set; }
    public string Token       { get; set; }
}
