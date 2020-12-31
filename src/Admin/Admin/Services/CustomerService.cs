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
    public class CustomerService 
    {
        private readonly DbContext dbContext;

        public CustomerService(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(CustomerModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
           
            dbContext.Set<Customer>().Add(new Customer
            {
                Name = model.Name,
                ContactPersion = model.ContactPerson,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
            });
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }

        public async Task DeleteAsync(int id)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            dbContext.Set<Customer>().Remove(dbContext.Set<Customer>().Find(id));
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }

        public Task<List<Customer>> GetAll()
        {
            return dbContext.Set<Customer>().AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(CustomerModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var entity = dbContext.Set<Customer>().Find(model.Id);
            entity.UpdateTime = DateTime.Now;
            entity.Name = model.Name;
            entity.ContactPersion = model.ContactPerson;
            dbContext.Set<Customer>().Update(entity);
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }
    }
}
