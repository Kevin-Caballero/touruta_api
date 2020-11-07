using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Touruta.Core.Entities;
using Touruta.Core.Interfaces;
using Touruta.Infrastructure.Data;

namespace Touruta.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TourutaContext _context;
        protected readonly DbSet<T> _entities;
        
        public BaseRepository(TourutaContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
             await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }
    }
}