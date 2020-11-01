using System.Threading.Tasks;
using Touruta.Core.Entities;
using Touruta.Core.Interfaces;
using Touruta.Infrastructure.Data;

namespace Touruta.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TourutaContext _context;
        private readonly IRepository<Tour> _tourRepository;
        private readonly IRepository<User> _userRepository; 
        private readonly IRepository<Comment> _commentRepository; 
        
        public UnitOfWork(TourutaContext context)
        {
            _context = context;
        }

        public IRepository<Tour> TourRepository => _tourRepository ?? new BaseRepository<Tour>(_context);
        public IRepository<User> UserRepository => _userRepository ?? new BaseRepository<User>(_context);
        public IRepository<Comment> CommentRepository => _commentRepository ?? new BaseRepository<Comment>(_context);
        
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
        
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}