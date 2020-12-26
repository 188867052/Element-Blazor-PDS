using Element.Admin;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Admin.ServerRender
{
    public class MainLayoutBase : LayoutComponentBase
    {
        protected List<MenuModel> Menus { get; set; } = new List<MenuModel>();

        protected override void OnInitialized()
        {

            Menus.Add(new MenuModel()
            {
                Label = "首页",
                Icon = "el-icon-star-on",
                Route = "/products"
            });
            Menus.Add(new MenuModel()
            {
                Label = "问题数据库",
                Icon = "el-icon-document",
                Children = new List<MenuModel>()
                {
                    new MenuModel(){
                         Label="入门文档",
                         Icon="el-icon-s-promotion",
                         Route="/docs/quickstart"
                    },
                    new MenuModel(){
                         Label="组件文档",
                         Icon="el-icon-s-management",
                         Route="/docs/component"
                    }
                }
            }); ;

        }
    }
}
