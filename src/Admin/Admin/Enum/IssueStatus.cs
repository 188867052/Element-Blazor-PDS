using System.ComponentModel;

namespace Element.Admin
{
    public enum IssueStatus
    {
        [Description("待处理")]
        Waitting,

        [Description("已完成")]
        Finished,
    }
}
