using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Touruta.Core.Entities;

namespace Touruta.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}