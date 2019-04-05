using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Chatman.Persistence.EF.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ChatmanContext _context;

        public EfRepository(ChatmanContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public ICollection<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(IBaseId id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));

            var result = _context.Set<T>().FirstOrDefault(x => x.Id.Value == id.Value);

            return result;
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();

        }
    }
}
