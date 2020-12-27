using Element.Admin.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace Element.Admin.ServerRender
{
    public class IssueService : IIssueService
    {
        private readonly DbContext dbContext;

        public IssueService(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(IssueModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            dbContext.Set<Entity.Issue>().Add(new Entity.Issue
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
            dbContext.Set<Entity.Issue>().Remove(dbContext.Set<Entity.Issue>().Find(id));
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }

        public Task<List<Entity.Issue>> GetAll()
        {
            return dbContext.Set<Entity.Issue>().AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(IssueModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var entity = dbContext.Set<Entity.Issue>().Find(model.Id);
            entity.UpdateTime = DateTime.Now;
            entity.Name = model.Name;
            entity.Status = model.Status;
            entity.Description = model.Description;
            dbContext.Set<Entity.Issue>().Update(entity);
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }
    }
}
