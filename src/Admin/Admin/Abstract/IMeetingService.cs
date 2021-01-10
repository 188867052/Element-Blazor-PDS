using IssueManage.Pages.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IssueManage.Pages.Abstract
{
    public interface IMeetingService
    {
        Task AddAsync(ScoreModel model);
        Task DeleteAsync(int id);
        Task UpdateAsync(ScoreModel model);
        Task<List<Score>> GetAll();
    }
}
