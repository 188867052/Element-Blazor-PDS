using CommandLine;

namespace IssueManage.Tool
{
    [Verb(nameof(Cmd))]
    public class CrmOption
    {
        [Option('c', HelpText = "[0:aaa]", MetaValue = "The type of the", Default = 0, Required = false)]
        public int Clear { get; set; }
    }
}
