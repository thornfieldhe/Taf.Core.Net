// See https://aka.ms/new-console-template for more information

using SqlSugar;
using System.ComponentModel.DataAnnotations;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using Taf.Core.Net.Utility;
using Taf.Core;


var db = new SqlSugarClient(new ConnectionConfig()
{
    ConnectionString      = "Server=192.168.10.155;Database=taf_core_net;Uid=root;Pwd=IKEqwe123;Allow User Variables=true;charset=utf8mb4;Default Command Timeout=120;",
    DbType                = DbType.MySql, //必填   
    IsAutoCloseConnection = true
  , ConfigureExternalServices = new ConfigureExternalServices{
        EntityService = (c, p) => {
            // int?  decimal?这种 isnullable=true
            if(c.PropertyType.IsGenericType
            && c.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)){
                p.IsNullable = true;
            } else if(c.PropertyType                            == typeof(string)
                   && c.GetCustomAttribute<RequiredAttribute>() == null){
                //string类型如果没有Required isnullable=true
                p.IsNullable = true;
            }
        }
    }
});
var identityTypes = Assembly
              .LoadFrom("Taf.Core.Net.Identity.dll") 
              .GetTypes().Where(it => it.FullName.Contains("Taf.Core.Net.Identity.Domain")&& !it.FullName.Contains("Taf.Core.Net.Identity.Domain.Share")).ToList();
var toolTypes = Assembly
                   .LoadFrom("Taf.Core.Net.Tools.dll") 
                   .GetTypes().Where(it => it.FullName.Contains("Taf.Core.Net.Tools.Domain") 
                                        && !it.FullName.Contains("Taf.Core.Net.Tools.Domain.Share")).ToList();
// var businessType = Assembly
//                    .LoadFrom("EfootprintV3.Database.dll") 
//                    .GetTypes().Where(it => it.FullName.Contains("EfootprintV3.Database.Domain") 
//                                         && !it.FullName.Contains("EfootprintV3.Database.Domain.Share")).ToList();
 identityTypes.AddRange(toolTypes);
 // identityTypes.AddRange(businessType);
db.CodeFirst.SetStringDefaultLength(200).InitTables(identityTypes.ToArray());

Console.WriteLine("Complited !");
