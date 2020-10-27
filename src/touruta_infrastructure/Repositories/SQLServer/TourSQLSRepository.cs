using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Touruta.Core.Entities;
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

        public async Task<bool> PutTour(Tour tour)
        {
            var currentTour = await GetTour(tour.IdTour);
            currentTour.Date = tour.Date;
            currentTour.Description = tour.Description;
            currentTour.Image = tour.Image;
            currentTour.Audio = tour.Audio;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteTour(int id)
        {
            var currentTour = await GetTour(id);
            _context.Tours.Remove(currentTour);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
