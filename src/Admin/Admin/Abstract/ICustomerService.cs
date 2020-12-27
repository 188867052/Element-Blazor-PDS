using Element.Admin.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Element.Admin.Abstract
{
    public interface ICustomerService
    {
        Task AddAsync(CustomerModel model);
        Task UpdateAsync(CustomerModel model);
        Task<List<Customer>> GetAll();
    }
}
