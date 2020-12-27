using Element.Admin.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Element.Admin.Abstract
{
    public interface IProductService : ITransientService
    {
        Task AddAsync(ProductModel model);
        Task DeleteAsync(int id);
        Task UpdateAsync(ProductModel model);
        Task<List<Product>> GetAll();
    }
}
