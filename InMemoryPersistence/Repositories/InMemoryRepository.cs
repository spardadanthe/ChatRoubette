using Chatman;
using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InMemoryPersistence.Repositories
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ICollection<T> storage = new List<T>();

        public IEnumerable<T> GetAll()
        {
            return storage;
        }

        public void Add(T entity)
        {
            storage.Add(entity);
        }

        public T GetById(IBaseId id)
        {
            return storage.FirstOrDefault(x => x.Id == id);
        }

        public void Update(T entity)
        {
            storage.ToHashSet().RemoveWhere(x => x.Id.Value == entity.Id.Value);
            Add(entity);
        }
    }
}
