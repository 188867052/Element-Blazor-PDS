using IssueManage.Pages;
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
                Label = "药品管理",
                Icon = "el-icon-document",
                Route = "/drug"
            });

            Menus.Add(new MenuModel()
            {
                Label = "科室管理",
                Icon = "el-icon-cpu",
                Route = "/department"
            });
        }
    }
}
