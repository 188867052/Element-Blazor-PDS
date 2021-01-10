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
                Label = "学生管理",
                Icon = "el-icon-document",
                Route = "/student"
            });

            Menus.Add(new MenuModel()
            {
                Label = "学分管理",
                Icon = "el-icon-cpu",
                Route = "/score"
            });
            //Menus.Add(new MenuModel()
            //{
            //    Label = "医生管理",
            //    Icon = "el-icon-cpu",
            //    Route = "/department2"
            //});
            //Menus.Add(new MenuModel()
            //{
            //    Label = "病人管理",
            //    Icon = "el-icon-cpu",
            //    Route = "/department3"
            //});
        }
    }
}
