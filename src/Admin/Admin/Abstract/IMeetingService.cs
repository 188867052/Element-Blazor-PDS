using IssueManage.Pages.Entity;
using IssueManage.Pages.Meetings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IssueManage.Pages.Abstract
{
    public interface IMeetingService
    {
        Task AddAsync(DepartmentModel model);
        Task DeleteAsync(int id);
        Task UpdateAsync(DepartmentModel model);
        Task<List<Department>> GetAll();
    }
}
