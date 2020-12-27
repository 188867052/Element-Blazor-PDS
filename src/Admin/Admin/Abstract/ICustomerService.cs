using IssueManage.Pages.Entity;
using IssueManage.Pages.Setting.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IssueManage.Pages.Abstract
{
    public interface ICustomerService
    {
        Task AddAsync(CustomerModel model);
        Task DeleteAsync(int id);
        Task UpdateAsync(CustomerModel model);
        Task<List<Customer>> GetAll();
    }
}
