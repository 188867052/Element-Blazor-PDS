using Element;
using System;
using System.ComponentModel;

namespace IssueManage.Pages
{
    public enum Sex
    {
        [Description("男")]
        Male,

        [Description("女")]
        Female
    }
    public class StudentModel
    {
        public int Id { get; set; }

        [TableColumn(Text = "学生名称")]
        public string Name { get; set; }

        [TableColumn(Text = "性别")]
        public Sex Sex { get; set; }

        [TableColumn(Text = "学号")]
        public string Number { get; set; }

        [TableColumn(Text = "创建时间")]
        public DateTime CreateTime { get; set; }

        [TableColumn(Text = "更新时间")]
        public DateTime UpdateTime { get; set; }
    }
}
