using System;

namespace IssueManage.Pages.Entity
{
    public class Score
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public int ScoreNumber { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
