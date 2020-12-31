using IssueManage.Pages.Enums;
using System;

namespace IssueManage.Pages.Issues
{
    public class IssueEditModel
    {
        public int Id { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime ImplementTime { get; set; }

        public string Description { get; set; }

        public string Product { get; set; }

        public string ChangeFrom { get; set; }

        public IssueStatus Status { get; set; }

        public IssueLevel Level { get; set; }
    }
}
