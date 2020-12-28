﻿using Element;
using IssueManage.Pages.Enums;
using System;

namespace IssueManage.Pages.Issues
{
    public class IssueEditModel
    {
        public int Id { get; set; }

        public DateTime ImplementTime { get; set; }

        public string Description { get; set; }
    }

    public class IssueListModel
    {
        public int Id { get; set; }

        [TableColumn(Text = "发起时间")]
        public DateTime CreateTime { get; set; }

        //[TableColumn(Text = "实施时间")]
        //public DateTime ImplementTime { get; set; }

        [TableColumn(Text = "问题描述")]
        public string Description { get; set; }

        [TableColumn(Text = "涉及产品")]
        public string Product { get; set; } = "轴承";

        [TableColumn(Text = "变化来源")]
        public string ChangeFrom { get; set; } = "来源1";

        [TableColumn(Text = "状态")]
        public IssueStatus Status { get; set; }
    }
}
