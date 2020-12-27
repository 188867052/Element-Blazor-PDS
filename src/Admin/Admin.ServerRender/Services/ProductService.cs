﻿using Element.Admin.Abstract;
using Element.Admin.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace Element.Admin.ServerRender
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
            dbContext.Set<Product>().Update(new Product
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                UpdateTime = DateTime.Now,
            });
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }
    }
}
