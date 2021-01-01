using IssueManage.Pages;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace IssueManage
{
    public class MainLayoutBase : LayoutComponentBase
    {
        protected List<MenuModel> Menus { get; set; } = new List<MenuModel>();

        protected override void OnInitialized()
        {
            Menus.Add(new MenuModel()
            {
                Label = "首页",
                Icon = "el-icon-s-home",
                Route = "/"
            });
            Menus.Add(new MenuModel()
            {
                Label = "问题库",
                Icon = "el-icon-document",
                Children = new List<MenuModel>()
                {
                    new MenuModel(){
                         Label="问题数据库",
                         Icon="el-icon-s-promotion",
                         Route="/issue"
                    },
                    new MenuModel(){
                         Label="问题状态表",
                         Icon="el-icon-cpu",
                         Route="/issue/edit"
                    }
                }
            });

            Menus.Add(new MenuModel()
            {
                Label = "会议系统",
                Icon = "el-icon-document",
                Children = new List<MenuModel>()
                {
                    new MenuModel(){
                         Label="我的会议",
                         Icon="el-icon-cpu",
                         Route="/meeting"
                    },
                    new MenuModel(){
                         Label="发起会议",
                         Icon="el-icon-cpu",
                    }
                }
            });

            Menus.Add(new MenuModel()
            {
                Label = "变化点",
                Icon = "el-icon-document",
                Children = new List<MenuModel>()
                {
                    new MenuModel(){
                         Label="时间轴",
                         Icon="el-icon-cpu",
                    },
                    new MenuModel(){
                         Label="新建变化点",
                         Icon="el-icon-cpu",
                    }
                }
            });

            Menus.Add(new MenuModel()
            {
                Label = "统计图",
                Icon = "el-icon-document",
            });

            Menus.Add(new MenuModel()
            {
                Label = "质量工具",
                Icon = "el-icon-document",
            });


            Menus.Add(new MenuModel()
            {
                Label = "设置",
                Icon = "el-icon-setting",
                Children = new List<MenuModel>()
                {
                    new MenuModel(){
                         Label="客户管理",
                         Icon="el-icon-s-custom",
                         Route="/customer"
                    },
                    new MenuModel(){
                         Label="产品管理",
                         Icon="el-icon-s-management",
                         Route="/product"
                    }
                }
            });
        }
    }
}
