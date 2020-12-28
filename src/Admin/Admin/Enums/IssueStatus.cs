using System.ComponentModel;

namespace IssueManage.Pages.Enums
{
    public enum IssueStatus
    {
        [Description("待处理")]
        Waitting,

        [Description("已完成")]
        Finished,
    }
}
