using System.ComponentModel;

namespace IssueManage.Pages.Enum
{
    public enum IssueStatus
    {
        [Description("待处理")]
        Waitting,

        [Description("已完成")]
        Finished,
    }
}
