using AutoMapper;
using Chatman.Persistence.EF.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Chatman.Persistence.EF.Repositories
{
    public class EfRepository<TBusinessModel,DtoModel> : IRepository<TBusinessModel> 
        where TBusinessModel : BaseEntity
        where DtoModel : class, IDtoId 
    {
        private readonly ChatmanContext _context;
        private readonly IMapper mapper;

        public EfRepository(ChatmanContext context,IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public void Add(TBusinessModel entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));


            var mapped = mapper.Map<DtoModel>(entity);

            _context.Set<DtoModel>().Add(mapped);
            _context.SaveChanges();
        } 

        public ICollection<TBusinessModel> GetAll()
        {
            var all = _context.Set<DtoModel>().ToList();
            var result = mapper.Map<ICollection<TBusinessModel>>(all);

            return result;
                
        }

        public TBusinessModel GetById(IBaseId id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));

            var model = _context.Set<DtoModel>().FirstOrDefault(x => x.Id == id.Value);

            var mappedModel = mapper.Map<TBusinessModel>(model);

            return mappedModel;
        }

        public void Update(TBusinessModel entity)
        {
            var mappedEntity = mapper.Map<DtoModel>(entity);
            _context.Entry(mappedEntity).State = EntityState.Modified;
            _context.SaveChanges();

        }


    }
}
