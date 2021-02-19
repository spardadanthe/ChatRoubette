using AutoMapper;
using Chatman.Persistence.EF.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Chatman.Persistence.EF.Repositories
{
    public class EfRepository<TBusinessModel, DtoModel> : IRepository<TBusinessModel>
        where TBusinessModel : BaseEntity
        where DtoModel : class, IDtoId
    {
        private readonly ChatmanContext _context;
        private readonly IMapper mapper;

        public EfRepository(ChatmanContext context, IMapper mapper)
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

        public IEnumerable<TBusinessModel> GetAll()
        {
            //var all = _context.Set<DtoModel>().ToList();
            //var result = mapper.Map<ICollection<TBusinessModel>>(all);

            var query = _context.Set<DtoModel>().AsQueryable();

            foreach (var property in _context.Model.FindEntityType(typeof(DtoModel)).GetNavigations())
                query = query.Include(property.Name);

            var all = query.ToList();

            var mappedModel = mapper.Map<ICollection<TBusinessModel>>(all);

            return mappedModel;

        }

        public TBusinessModel GetById(IBaseId id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));

            var query = _context.Set<DtoModel>().AsQueryable();

            foreach (var property in _context.Model.FindEntityType(typeof(DtoModel)).GetNavigations())
                query = query.Include(property.Name);

            var model = query.FirstOrDefault(x => x.Id.Equals(id.Value));

            //_context.Entry(model).State = EntityState.Detached;

            var mappedModel = mapper.Map<TBusinessModel>(model);

            return mappedModel;
        }

        private DtoModel GetByIdAsDto(IBaseId id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));

            var query = _context.Set<DtoModel>().AsQueryable();

            foreach (var property in _context.Model.FindEntityType(typeof(DtoModel)).GetNavigations())
                query = query.Include(property.Name);

            var model = query.FirstOrDefault(x => x.Id.Equals(id.Value));

            return model;
        }

        public void Update(TBusinessModel entity)
        {
            var dto = GetByIdAsDto(entity.Id);
            var mappedEntity = mapper.Map(entity,dto);

            //foreach (var prop in _context.Entry(mappedEntity).Collections)
            //{
            //    if(prop.CurrentValue is null == false)
            //    {
            //        foreach (var val in prop.CurrentValue)
            //        {
            //            var a = _context.Entry(val).State;
            //            _context.Attach(val);
            //        }
            //    }

            //}

            _context.SaveChanges();

            
        }


    }
}
