using AutoMapper;
using IssueManage.Pages.Abstract;
using IssueManage.Pages.Entity;
using IssueManage.Pages.Issues;
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
        private readonly IMapper mapper;

        public IssueService(DbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task AddAsync(IssueModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            var issue = mapper.Map<IssueModel, Issue>(model);
            issue.CreateTime = DateTime.Now;
            issue.UpdateTime = DateTime.Now;
            dbContext.Set<Issue>().Add(issue);
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }

        public async Task DeleteAsync(int id)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            dbContext.Set<Issue>().Remove(dbContext.Set<Issue>().Find(id));
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }

        public Task<List<Issue>> GetAll()
        {
            return dbContext.Set<Issue>().AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(IssueModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var entity = dbContext.Set<Issue>().Find(model.Id);
            mapper.Map(model, entity);
            entity.UpdateTime = DateTime.Now;
            dbContext.Set<Issue>().Update(entity);
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }
    }
}
