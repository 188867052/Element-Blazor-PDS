using Element;
using IssueManage.Pages.Enums;
using System;

namespace IssueManage
{
    public class IssueGridModel
    {
        public int Id { get; set; }

        [TableColumn(Text = "发起时间")]
        public DateTime CreateTime { get; set; }

        [TableColumn(Text = "实施时间")]
        public DateTime ImplementTime { get; set; }

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
