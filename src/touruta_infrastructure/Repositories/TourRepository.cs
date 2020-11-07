using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Touruta.Core.Entities;
using Touruta.Core.Interfaces;
using Touruta.Infrastructure.Data;

namespace Touruta.Infrastructure.Repositories
{
    public class TourRepository : BaseRepository<Tour>, ITourRepository
    {
        public TourRepository(TourutaContext context) : base(context) { }

        public async Task<IEnumerable<Tour>> GetToursByUser(int userId)
        {
            return await _entities.Where(x => x.IdUser == userId).ToListAsync();
        }

        public async Task<Tour> GetLastTourByUser(int userId)
        {
            return _entities.Where(x => x.IdUser == userId).OrderByDescending(x => x.Date).FirstOrDefault();
        }
    }
}