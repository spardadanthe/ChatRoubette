using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chatman.Persistence.EF.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ChatmanContext context;

        public EfRepository(string connectionString)
        {
            context = new ChatmanContext(connectionString);
        }

        public void Add(T entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            context.Set<T>().Add(entity);
        }

        public ICollection<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(IBaseId id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));

            return context.Set<T>().FirstOrDefault(x => x.Id == id);
        }
    }
}
