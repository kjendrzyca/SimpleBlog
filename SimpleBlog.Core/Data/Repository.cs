using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace SimpleBlog.Core.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext DbContext;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(IDbContextFactory dbContextFactory)
        {
            DbContext = dbContextFactory.GetContext();
            DbSet = DbContext.Set<TEntity>();
        }

        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
            DbContext.SaveChanges();
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (DbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
            DbContext.SaveChanges();
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            DbContext.Entry(entityToUpdate).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }
    }
}
