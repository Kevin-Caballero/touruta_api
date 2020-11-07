using System.Collections.Generic;
using System.Threading.Tasks;
using Touruta.Core.Entities;

namespace Touruta.Core.Interfaces
{
    public interface ITourRepository : IRepository<Tour>
    {
        Task<IEnumerable<Tour>> GetToursByUser(int userId);
        Task<Tour> GetLastTourByUser(int userId);
    }
}
