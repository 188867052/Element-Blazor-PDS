using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace IssueManage
{
    public class MeetingService 
    {
        private readonly DbContext dbContext;

        public MeetingService(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(MeetingModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
           
            dbContext.Set<Meeting>().Add(new Meeting
            {
                Topic = model.Topic,
                Content = model.Content,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
            });
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }

        public async Task DeleteAsync(int id)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            dbContext.Set<Meeting>().Remove(dbContext.Set<Meeting>().Find(id));
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }

        public Task<List<Meeting>> GetAll()
        {
            return dbContext.Set<Meeting>().AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(MeetingModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var entity = dbContext.Set<Meeting>().Find(model.Id);
            entity.UpdateTime = DateTime.Now;
            entity.Topic = model.Topic;
            entity.Content = model.Content;
            dbContext.Set<Meeting>().Update(entity);
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }
    }
}
