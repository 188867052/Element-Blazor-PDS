using System;

namespace IssueManage.Pages.Entity
{
    public class Score
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public string Remark { get; set; }
        public int ScoreNumber { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
