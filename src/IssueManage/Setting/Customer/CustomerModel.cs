using Element;
using System;

namespace IssueManage
{
    public class CustomerModel
    {
        public int Id { get; set; }

        [TableColumn(Text = "客户名称")]
        public string Name { get; set; }

        [TableColumn(Text = "联系人")]
        public string ContactPerson { get; set; }

        [TableColumn(Text = "创建时间")]
        public DateTime CreateTime { get; set; }
    }
}
