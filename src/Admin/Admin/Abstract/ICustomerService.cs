using IssueManage.Pages.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IssueManage.Pages.Abstract
{
    public interface ICustomerService
    {
        Task AddAsync(StudentModel model);
        Task DeleteAsync(int id);
        Task UpdateAsync(StudentModel model);
        Task<List<Entity.Student>> GetAll();
    }
}
