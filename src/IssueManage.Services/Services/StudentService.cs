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
    public class StudentService : IStudentService
    {
        private readonly DbContext dbContext;

        public StudentService(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(StudentModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
           
            dbContext.Set<Student>().Add(new Student
            {
                Name = model.Name,
                Sex = model.Sex,
                Number = model.Number,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
            });
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }

        public async Task DeleteAsync(int id)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            dbContext.Set<Student>().Remove(dbContext.Set<Student>().Find(id));
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }

        public Task<List<Student>> GetAll()
        {
            return dbContext.Set<Student>().AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(StudentModel model)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var entity = dbContext.Set<Student>().Find(model.Id);
            entity.UpdateTime = DateTime.Now;
            entity.Name = model.Name;
            entity.Sex = model.Sex;
            entity.Number = model.Number;
            dbContext.Set<Student>().Update(entity);
            await dbContext.SaveChangesAsync();
            scope.Complete();
        }
    }
}
