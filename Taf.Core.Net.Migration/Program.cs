// See https://aka.ms/new-console-template for more information

using SqlSugar;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using Taf.Core.Net.Utility.Entity;
using Taf.Core;


var db = new SqlSugarClient(new ConnectionConfig()
{
    ConnectionString      = "Server=192.168.10.155;Database=taf_core_net;Uid=root;Pwd=IKEqwe123;Allow User Variables=true;charset=utf8mb4;Default Command Timeout=120;",
    DbType                = DbType.MySql, //必填   
    IsAutoCloseConnection = true
});
var identityTypes = Assembly
              .LoadFrom("Taf.Core.Net.Identity.dll") 
              .GetTypes().Where(it => it.FullName.Contains("Taf.Core.Net.Identity.Domain")&& !it.FullName.Contains("Taf.Core.Net.Identity.Domain.Share")).ToList();
var toolTypes = Assembly
                   .LoadFrom("Taf.Core.Net.Tools.dll") 
                   .GetTypes().Where(it => it.FullName.Contains("Taf.Core.Net.Tools.Domain") && !it.FullName.Contains("Taf.Core.Net.Tools.Domain.Share")).ToList();
 identityTypes.AddRange(toolTypes);
db.CodeFirst.SetStringDefaultLength(200).InitTables(identityTypes.ToArray());

Console.WriteLine("Complited !");
