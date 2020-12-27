using Element.Admin.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Element.Admin.Abstract
{
    public interface IMeetingService
    {
        Task AddAsync(MeetingModel model);
        Task DeleteAsync(int id);
        Task UpdateAsync(MeetingModel model);
        Task<List<Meeting>> GetAll();
    }
}
