using IssueManage.Pages.Entity;
using IssueManage.Pages.Setting.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IssueManage.Pages.Abstract
{
    public interface IProductService : ITransientService
    {
        Task AddAsync(ProductModel model);
        Task DeleteAsync(int id);
        Task UpdateAsync(ProductModel model);
        Task<List<Patient>> GetAll();
    }
}
