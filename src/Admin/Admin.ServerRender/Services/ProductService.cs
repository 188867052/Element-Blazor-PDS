using IssueManage.Pages.Abstract;
using IssueManage.Pages.Entity;
using IssueManage.Pages.Setting.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace IssueManage.Services
{
    public class ProductService : IProductService
    {
        private readonly DbContext dbContext;

        public ProductService(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(ProductModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            dbContext.Set<Product>().Add(new Product
            {
                Name = model.Name,
                Description = model.Description,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
            });
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }

        public async Task DeleteAsync(int id)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            dbContext.Set<Product>().Remove(dbContext.Set<Product>().Find(id));
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }

        public Task<List<Product>> GetAll()
        {
            return dbContext.Set<Product>().AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(ProductModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var entity = dbContext.Set<Product>().Find(model.Id);
            entity.UpdateTime = DateTime.Now;
            entity.Name = model.Name;
            entity.Description = model.Description;
            dbContext.Set<Product>().Update(entity);
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }
    }
}
