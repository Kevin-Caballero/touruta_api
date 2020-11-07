using System;
using System.Threading.Tasks;
using Touruta.Core.Entities;

namespace Touruta.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITourRepository TourRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<Comment> CommentRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}