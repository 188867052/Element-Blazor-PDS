using System;

namespace IssueManage
{
    public class Issue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public IssueStatus Status { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string ChangeFrom { get; internal set; }
        public DateTime ImplementTime { get; internal set; }
        public string Product { get; internal set; }
    }
}
