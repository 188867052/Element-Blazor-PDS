using IssueManage.Pages.Abstract;
using IssueManage.Pages.Entity;
using IssueManage.Pages.Setting.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace IssueManage.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DbContext dbContext;

        public CustomerService(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(DrugModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
           
            dbContext.Set<Drug>().Add(new Drug
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Amount = model.Amount,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
            });
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }

        public async Task DeleteAsync(int id)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            dbContext.Set<Drug>().Remove(dbContext.Set<Drug>().Find(id));
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }

        public Task<List<Drug>> GetAll()
        {
            return dbContext.Set<Drug>().AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(DrugModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var entity = dbContext.Set<Drug>().Find(model.Id);
            entity.UpdateTime = DateTime.Now;
            entity.Name = model.Name;
            entity.Price = model.Price;
            entity.Description = model.Description;
            entity.Amount = model.Amount;
            entity.Price = model.Price;
            dbContext.Set<Drug>().Update(entity);
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }
    }
}
