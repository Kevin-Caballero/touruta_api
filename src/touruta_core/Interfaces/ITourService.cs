using System.Collections.Generic;
using System.Threading.Tasks;
using Touruta.Core.CustomEntities;
using Touruta.Core.Entities;
using Touruta.Core.QueryFilters;

namespace Touruta.Core.Interfaces
{
    public interface ITourService
    {
        PagedList<Tour> GetTours(TourQueryFilter filters);
        Task<Tour> GetTour(int id);
        Task PostTour(Tour tour);
        Task<bool> PutTour(Tour tour);
        Task<bool> DeleteTour(int id);
    }
}