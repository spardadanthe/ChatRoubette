using System.Collections.Generic;

namespace Persistence.Services
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();

        void Add(T entity);
    }
}
