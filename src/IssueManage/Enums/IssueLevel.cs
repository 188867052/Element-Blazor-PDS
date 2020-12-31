using System.ComponentModel;

namespace IssueManage
{
    public enum IssueLevel
    {
        [Description("严重")]
        Serious,

        [Description("一般")]
        Normal,
    }
}
