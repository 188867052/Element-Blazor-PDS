using Element.Admin.Abstract;
using Element.Admin.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace Element.Admin.ServerRender
{
    public class CustomerService : ICustomerService
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

        public Task<List<Customer>> GetAll()
        {
            return dbContext.Set<Customer>().AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(CustomerModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            dbContext.Set<Customer>().Update(new Customer
            {
                Id = model.Id,
                Name = model.Name,
                ContactPersion = model.ContactPerson,
                UpdateTime = DateTime.Now,
            });
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }
    }
}
