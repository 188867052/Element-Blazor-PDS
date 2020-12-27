using Element.Admin.Abstract;
using Element.Admin.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Element.Admin.ServerRender
{
    public class CustomerService : ICustomerService
    {
        private readonly DbContext dbContext;

        public CustomerService(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(CustomerModel model)
        {
            dbContext.Set<Customer>().Add(new Customer
            {
                Name = model.Name,
                ContactPersion = model.ContactPerson,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
            });
            dbContext.SaveChanges();
        }

        public Task<List<Customer>> GetAll()
        {
            return dbContext.Set<Customer>().ToListAsync();
        }

        public void Update(CustomerModel model)
        {
            dbContext.Set<Customer>().Update(new Customer
            {
                Id = model.Id,
                Name = model.Name,
                ContactPersion = model.ContactPerson,
                UpdateTime = DateTime.Now,
            });
            dbContext.SaveChanges();
        }
    }
}
