using Chatman;
using System.Collections.Generic;

namespace Persistence.Interfaces
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();

        T GetById(IBaseId id);

        void Add(T entity);

        void Update(T entity);
    }
}
