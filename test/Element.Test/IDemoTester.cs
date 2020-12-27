using System.Threading.Tasks;

namespace IssueManage.Test
{
    public interface IDemoTester
    {
        Task TestAsync(DemoCard demoCard);
    }
}
