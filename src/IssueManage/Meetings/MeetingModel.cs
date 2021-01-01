using Element;
using System;

namespace IssueManage
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

    public class MeetingGridModel
    {
        public int Id { get; set; }

        [TableColumn(Text = "会议时间")]
        public DateTime MeetingTime { get; set; }

        [TableColumn(Text = "会议性质")]
        public DateTime MeetingType { get; set; }

        [TableColumn(Text = "议题")]
        public string Topic { get; set; }

        [TableColumn(Text = "发起人")]
        public string Person { get; set; }

        [TableColumn(Text = "行动数")]
        public int Count { get; set; }

        [TableColumn(Text = "状态")]
        public int Status { get; set; }

        [TableColumn(Text = "内容")]
        public string Content { get; set; }

        [TableColumn(Text = "会议背景")]
        public string UpdateTime { get; set; }
    }
}
