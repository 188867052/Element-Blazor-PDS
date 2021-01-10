using Element;
using System;

namespace IssueManage.Pages.Meetings
{
    public class ScoreModel
    {
        public int Id { get; set; }

        [TableColumn(Text = "科室名称")]
        public string Name { get; set; }

        [TableColumn(Text = "主任")]
        public string Header { get; set; }

        [TableColumn(Text = "描述")]
        public string Remark { get; set; }

        [TableColumn(Text = "创建时间")]
        public DateTime CreateTime { get; set; }

        [TableColumn(Text = "更新时间")]
        public DateTime UpdateTime { get; set; }
    }
}
