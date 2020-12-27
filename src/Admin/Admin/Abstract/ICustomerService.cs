using Element.Admin.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Element.Admin.Abstract
{
    public interface ICustomerService
    {
        void Add(CustomerModel model);
        void Update(CustomerModel model);
        Task<List<Customer>> GetAll();
    }
}
