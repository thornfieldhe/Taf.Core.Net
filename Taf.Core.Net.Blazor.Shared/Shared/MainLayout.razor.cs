using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Taf.Core.Net.Blazor.Shared.Shared{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class MainLayout{
        private bool UseTabSet{ get; set; } = true;

        private string Theme{ get; set; } = "";

        private bool IsOpen{ get; set; }

        private bool IsFixedHeader{ get; set; } = true;

        private bool IsFixedFooter{ get; set; } = true;

        private bool IsFullSide{ get; set; } = true;

        private bool ShowFooter{ get; set; } = true;

        private List<MenuItem>? Menus{ get; set; }

        /// <summary>
        /// OnInitialized 方法
        /// </summary>
        protected override void OnInitialized(){
            base.OnInitialized();

            Menus = GetIconSideMenuItems();
        }

        private static List<MenuItem> GetIconSideMenuItems(){
            var menus = new List<MenuItem>{
                new(){ Text = "主页", Icon = "fa fa-fw fa-fa", Url = "/", Match = NavLinkMatch.All }
              , new(){
                    Text = "应用"
                  , Icon = "fa fa-fw fa-html5"
                  , Items = new[]{
                        new MenuItem(){ Text = "应用", Icon = "fa fa-fw fa-html5", Url = "/clients" }, new MenuItem(){ Text = "客户端", Icon = "fa fa-fw fa-users", Url = "users" }
                    }
                }
              , new MenuItem(){
                    Text = "数据库"
                  , Icon = "fa fa-fw fa-database"
                  , Items = new[]{
                        new MenuItem(){ Text = "数据库管理", Icon = "fa fa-fw fa-database", Url = "/databases" }
                      , new MenuItem(){ Text = "购买记录", Icon  = "fa fa-fw fa-money", Url    = "/payments" }
                    }
                }
              , new(){ Text          = "工具", Icon        = "fa fa-fw fa-database", Items     = new[]{ new MenuItem(){ Text = "短链", Icon = "fa fa-fw fa-link", Url = "/links" } } }
              , new(){ Text          = "系统", Icon        = "fa fa-fw fa-desktop", Items      = new[]{ new MenuItem(){ Text = "用户", Icon = "fa fa-fw user-o", Url  = "/links" } } }
              , new MenuItem(){ Text = "Table", Icon     = "fa fa-fw fa-table", Url          = "table" }
              , new MenuItem(){ Text = "Counter", Icon   = "fa fa-fw fa-check-square-o", Url = "/counter" }
              , new MenuItem(){ Text = "FetchData", Icon = "fa fa-fw fa-database", Url       = "fetchdata" }
            };

            return menus;
        }
    }
}
