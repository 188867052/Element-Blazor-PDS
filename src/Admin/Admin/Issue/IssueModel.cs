using System;

namespace Element.Admin
{
    public class IssueModel
    {
        public int Id { get; set; }

        [TableColumn(Text = "问题名称")]
        public string Name { get; set; }

        [TableColumn(Text = "描述")]
        public string Description { get; set; }

        [TableColumn(Text = "状态")]
        public IssueStatus Status { get; set; }

        [TableColumn(Text = "创建时间")]
        public DateTime CreateTime { get; set; }    
        
        [TableColumn(Text = "更新时间")]
        public DateTime UpdateTime { get; set; }
    }
}
