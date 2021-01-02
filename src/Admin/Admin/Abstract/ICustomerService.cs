using IssueManage.Pages.Entity;
using IssueManage.Pages.Setting.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IssueManage.Pages.Abstract
{
    public interface ICustomerService
    {
        Task AddAsync(DrugModel model);
        Task DeleteAsync(int id);
        Task UpdateAsync(DrugModel model);
        Task<List<Drug>> GetAll();
    }
}
