using Element;
using System;

namespace IssueManage.Pages
{
    public class ScoreModel
    {
        public int Id { get; set; }

        [TableColumn(Text = "学生名称")]
        public string Name { get; set; }

        [TableColumn(Ignore =true)]
        public int StudentId { get; set; }

        [TableColumn(Text = "学分")]
        public int ScoreNumber { get; set; }

        [TableColumn(Text = "描述")]
        public string Remark { get; set; }

        [TableColumn(Text = "创建时间")]
        public DateTime CreateTime { get; set; }

        [TableColumn(Text = "更新时间")]
        public DateTime UpdateTime { get; set; }
    }
}
