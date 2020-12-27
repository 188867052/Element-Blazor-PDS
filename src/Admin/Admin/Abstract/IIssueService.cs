using IssueManage.Pages.Entity;
using IssueManage.Pages.Issues;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IssueManage.Pages.Abstract
{
    public interface IIssueService
    {
        Task AddAsync(IssueModel model);
        Task DeleteAsync(int id);
        Task UpdateAsync(IssueModel model);
        Task<List<Issue>> GetAll();
    }
}
