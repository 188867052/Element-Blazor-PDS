using Element;
using System;

namespace IssueManage
{
    public class IndexModel
    {
        public int Id { get; set; }

        [TableColumn(Text = "产品名称")]
        public string Name { get; set; }

        [TableColumn(Text = "描述")]
        public string Description { get; set; }

        [TableColumn(Text = "创建时间")]
        public DateTime CreateTime { get; set; }
    }
}
