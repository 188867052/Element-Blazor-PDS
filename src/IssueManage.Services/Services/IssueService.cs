using AutoMapper;
using IssueManage.Pages.Abstract;
using IssueManage.Pages.Entity;
using IssueManage.Pages.Issues;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace IssueManage.Services
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

        public async Task AddAsync(IssueEditModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            var issue = mapper.Map<IssueEditModel, Doctor>(model);
            issue.CreateTime = DateTime.Now;
            issue.UpdateTime = DateTime.Now;
            dbContext.Set<Doctor>().Add(issue);
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }

        public async Task DeleteAsync(int id)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            dbContext.Set<Doctor>().Remove(dbContext.Set<Doctor>().Find(id));
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }

        public Task<List<Doctor>> GetAll()
        {
            return dbContext.Set<Doctor>().AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(IssueEditModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var entity = dbContext.Set<Doctor>().Find(model.Id);
            mapper.Map(model, entity);
            entity.UpdateTime = DateTime.Now;
            dbContext.Set<Doctor>().Update(entity);
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }
    }
}
