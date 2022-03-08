using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Org.BouncyCastle.Math.EC;
using SqlSugar;
using SqlSugar.IOC;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using Taf.Core.Net.Tools.Domain;
using Taf.Core.Net.Tools.Services;
using Taf.Core.Net.Utility.Database;
using Taf.Core.Net.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBootstrapBlazor();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSqlsugarSetup(builder.Configuration,"MainConnection");

builder.Services.AddSingleton<IRepository<ShortUrl,Guid>,Repository<ShortUrl,Guid>>();
builder.Services.AddSingleton<IShortUrlService,ShortUrlService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if(!app.Environment.IsDevelopment()){
//     app.UseExceptionHandler("/Error");
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// }


// app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetCoreApiDemo v1");
    c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None); //折叠Api
    c.DefaultModelsExpandDepth(-1);                                     //去除Model 显示
});
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();

