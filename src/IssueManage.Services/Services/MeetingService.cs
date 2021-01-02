using IssueManage.Pages.Abstract;
using IssueManage.Pages.Entity;
using IssueManage.Pages.Meetings;
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

        public async Task AddAsync(DepartmentModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
           
            dbContext.Set<Department>().Add(new Department
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
            dbContext.Set<Department>().Remove(dbContext.Set<Department>().Find(id));
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }

        public Task<List<Department>> GetAll()
        {
            return dbContext.Set<Department>().AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(DepartmentModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var entity = dbContext.Set<Department>().Find(model.Id);
            entity.UpdateTime = DateTime.Now;
            entity.Name = model.Name;
            entity.Header = model.Header;
            entity.Remark = model.Remark;
            dbContext.Set<Department>().Update(entity);
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }
    }
}
