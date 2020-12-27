using System.Collections.Generic;
using System.Threading.Tasks;

namespace Element.Admin.Abstract
{
    public interface IIssueService
    {
        Task AddAsync(IssueModel model);
        Task DeleteAsync(int id);
        Task UpdateAsync(IssueModel model);
        Task<List<Entity.Issue>> GetAll();
    }
}
