using IssueManage.Pages.Entity;
using IssueManage.Pages.Issues;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IssueManage.Pages.Abstract
{
    public interface IIssueService
    {
        Task AddAsync(IssueGridModel model);
        Task DeleteAsync(int id);
        Task UpdateAsync(IssueGridModel model);
        Task<List<Issue>> GetAll();
    }
}
