using Microsoft.EntityFrameworkCore;
using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Vavatech.EFCore.IRepositories;

namespace Vavatech.EFCore.DbRepositories
{
    public class DbEntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly ShopContext context;

        protected DbSet<TEntity> entities => context.Set<TEntity>();

        private readonly Func<ShopContext, int, TEntity> getById;
        private readonly Func<ShopContext, IEnumerable<TEntity>> getAll;

        public DbEntityRepository(ShopContext context)
        {
            this.context = context;

            getById = EF.CompileQuery((ShopContext db, int id) => db.Set<TEntity>().SingleOrDefault(c => c.Id == id));
            getAll = EF.CompileQuery((ShopContext db) => db.Set<TEntity>().ToList());
        }

        public virtual void Add(TEntity entity)
        {
            entities.Add(entity);
            context.SaveChanges();
        }

        public virtual void AddRange(IEnumerable<TEntity> collection)
        {
            entities.AddRange(collection);
            context.SaveChanges();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            // return entities.ToList();
            return getAll(context);
        }

        public virtual TEntity Get(int id)
        {
            return getById(context, id);
            // return entities.Find(id);
        }

        public virtual void Remove(int id)
        {
            entities.Remove(Get(id));
            context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
