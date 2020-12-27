using IssueManage.Pages.Entity;
using IssueManage.Pages.Meetings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IssueManage.Pages.Abstract
{
    public interface IMeetingService
    {
        Task AddAsync(MeetingModel model);
        Task DeleteAsync(int id);
        Task UpdateAsync(MeetingModel model);
        Task<List<Meeting>> GetAll();
    }
}
