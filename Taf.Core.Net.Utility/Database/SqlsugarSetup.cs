// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlsugarSetup.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Sqlsugar 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using Taf.Core.Net.Domain.Entities;

// 何翔华
// Taf.Core.Net.Utility
// SqlsugarSetup.cs

namespace Taf.Core.Net.Utility.Database;

using System;

/// <summary>
/// Sqlsugar 启动配置
/// </summary>
public static class SqlsugarSetup{
    public static void AddSqlsugarSetup(
        this IServiceCollection services, IConfiguration configuration,
        string                  dbName = "MainConnection"){
        var sqlSugar = new SqlSugarScope(
            new ConnectionConfig(){
                DbType                = SqlSugar.DbType.MySql
              , ConnectionString      = configuration.GetConnectionString(dbName)
              , IsAutoCloseConnection = true
            },
            db => {
                //单例参数配置，所有上下文生效
                db.Aop.OnLogExecuting = (sql, pars) => {
                    Console.WriteLine(sql); //输出sql
                };

                db.Aop.DataExecuting = (oldValue, entityInfo) => {
                    //inset生效
                    if(entityInfo.PropertyName  == "CreationTime"
                    && entityInfo.OperationType == DataFilterType.InsertByObject){
                        entityInfo.SetValue(DateTime.UtcNow); //修改CreateTime字段
                    }

                    //update生效        
                    if(entityInfo.PropertyName  == "LastModificationTime"
                    && entityInfo.OperationType == DataFilterType.UpdateByObject){
                        entityInfo.SetValue(DateTime.UtcNow); //修改UpdateTime字段
                    }

                    //insert,update生效        
                    if(entityInfo.PropertyName  == "ConcurrencyStamp"){
                        entityInfo.SetValue(Guid.NewGuid().ToString()); //修改时间戳字段
                    }
                };
            });
        
        var    basePath1 = AppContext.BaseDirectory;
        var    basePath2 =Path.GetDirectoryName(typeof(SqlsugarSetup).Assembly.Location);
 
        var identityTypes = Assembly
                           .LoadFrom(Path.Combine(basePath2,"Taf.Core.Net.Identity.dll"))
                           .GetTypes().Where(it => it.FullName.Contains("Taf.Core.Net.Identity.Domain") && !it.FullName.Contains("Taf.Core.Net.Identity.Domain.Share"))
                           .ToList();
        var toolTypes = Assembly
                       .LoadFrom(Path.Combine(basePath2,"Taf.Core.Net.Tools.dll"))
                                     .GetTypes().Where(it => it.FullName.Contains("Taf.Core.Net.Tools.Domain") && !it.FullName.Contains("Taf.Core.Net.Tools.Domain.Share")).ToList();
        identityTypes.AddRange(toolTypes);
        var types = identityTypes.Union(toolTypes);
        // 遍历实体类
        foreach(var entityType in types){
            if(typeof(ISoftDelete).IsAssignableFrom(entityType) ){
                var softDelete = entityType as ISoftDelete;
                //判断实体类中包含IsDeleted属性
                //构建动态Lambda
                var lambda = DynamicExpressionParser.ParseLambda
                (new[] { Expression.Parameter(entityType, "isDelete") },
                 typeof(bool), " IsDeleted ==  @0 ",
                 false);
                sqlSugar.QueryFilter.Add(new TableFilterItem<object>(entityType, lambda)); //将Lambda传入过滤器
            }
        }
        services.AddSingleton<ISqlSugarClient>(sqlSugar);
        Console.WriteLine("Complited !");
    }
}
