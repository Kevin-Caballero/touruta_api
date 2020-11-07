using System.Collections.Generic;
using System.Threading.Tasks;
using Touruta.Core.Data;

namespace Touruta.Core.Interfaces
{
    public interface ITourRepository
    {
        Task<IEnumerable<Tour>> GetTours();
        Task<Tour> GetTour(int id);
    }
}
