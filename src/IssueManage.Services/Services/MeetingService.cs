using IssueManage.Pages;
using IssueManage.Pages.Abstract;
using IssueManage.Pages.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace IssueManage.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly DbContext dbContext;

        public MeetingService(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(ScoreModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
           
            dbContext.Set<Score>().Add(new Score
            {
                Name = model.Name,
                Remark = model.Remark,
                Header = model.Header,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
            });
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }

        public async Task DeleteAsync(int id)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            dbContext.Set<Score>().Remove(dbContext.Set<Score>().Find(id));
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }

        public Task<List<Score>> GetAll()
        {
            return dbContext.Set<Score>().AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(ScoreModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var entity = dbContext.Set<Score>().Find(model.Id);
            entity.UpdateTime = DateTime.Now;
            entity.Name = model.Name;
            entity.Header = model.Header;
            entity.Remark = model.Remark;
            dbContext.Set<Score>().Update(entity);
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }
    }
}
