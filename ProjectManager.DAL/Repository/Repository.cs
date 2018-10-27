using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectManager.DataLayer.Repository
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        protected readonly ProjectManagerContext Context;
        protected readonly DbSet<TEntity> Entities;

        public Repository(ProjectManagerContext context)
        {
            Context = context;
            Entities = Context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            var insertedEntity = Entities.Add(entity);
            Context.SaveChanges();
            return insertedEntity;
        }

        public TEntity Update(TEntity entity)
        {
            //Entities.Attach(entity);
            //Context.Entry(entity).State = EntityState.Modified;
            //Entities.Find(entity.id)
            Context.SaveChanges();
            return entity;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate);
        }

        public TEntity Get(int id)
        {
            return Entities.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Entities.ToList();
        }

        public void Remove(TEntity entity)
        {
            Entities.Remove(entity);
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
