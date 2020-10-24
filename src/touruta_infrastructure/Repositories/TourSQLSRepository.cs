using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Touruta.Core.Data;
using Touruta.Core.Interfaces;
using Touruta.Infrastructure.Data;

namespace Touruta.Infrastructure.Repositories
{
    public class TourSQLSRepository : ITourRepository
    {
        private readonly TourutaContext _context;
        public TourSQLSRepository(TourutaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tour>> GetTours()
        {
            var tours = await _context.Tours.ToListAsync();
            return tours;
        }
        
        public async Task<Tour> GetTour(int id)
        {
            var tour = await _context.Tours.FirstOrDefaultAsync(x => x.IdTour == id);
            return tour;
        }

        public async Task PostTour(Tour tour)
        {
            _context.Tours.Add(tour);
            await _context.SaveChangesAsync();
        }
    }
}
