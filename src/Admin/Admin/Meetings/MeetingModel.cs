using Element;
using System;

namespace IssueManage.Pages.Meetings
{
    public class MeetingModel
    {
        public int Id { get; set; }

        [TableColumn(Text = "议题")]
        public string Topic { get; set; }

        [TableColumn(Text = "内容")]
        public string Content { get; set; }

        [TableColumn(Text = "创建时间")]
        public DateTime CreateTime { get; set; }

        [TableColumn(Text = "更新时间")]
        public DateTime UpdateTime { get; set; }
    }
}
