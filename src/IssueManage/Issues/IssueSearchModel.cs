using System;

namespace IssueManage
{
    public class IssueSearchModel
    {
        public DateTime? StartCreateTime { get; set; }

        public DateTime? EndCreateTime { get; set; }

        public DateTime? ImplementTime { get; set; }

        public string Description { get; set; }

        public string Product { get; set; } = "轴承";

        public string ChangeFrom { get; set; } = "来源1";

        public IssueStatus? Status { get; set; }
    }
}
