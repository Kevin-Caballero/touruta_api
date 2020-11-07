using System.Collections.Generic;
using System.Threading.Tasks;
using Touruta.Core.Entities;

namespace Touruta.Core.Interfaces
{
    public interface ITourService
    {
        IEnumerable<Tour> GetTours();
        Task<Tour> GetTour(int id);
        Task PostTour(Tour tour);
        Task<bool> PutTour(Tour tour);
        Task<bool> DeleteTour(int id);
    }
}