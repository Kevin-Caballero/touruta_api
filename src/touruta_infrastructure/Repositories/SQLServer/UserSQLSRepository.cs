using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Touruta.Core.Entities;
using Touruta.Core.Interfaces;
using Touruta.Infrastructure.Data;

namespace Touruta.Infrastructure.Repositories
{
    public class UserSQLSRepository : IUserRepository
    {
        private readonly TourutaContext _context;
        public UserSQLSRepository(TourutaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        
        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.IdUser == id);
            return user;
        }
    }
}