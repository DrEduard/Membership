using Membership.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Membership.Repositories
{
    public interface IGenericRepository<TEntity>
    {
        List<TEntity> GetAll();

        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        TEntity Get(int id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id);

        void SaveChanges();
    }

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private bool disposed = false;
        protected ApplicationDbContext dbContext = null;

        protected DbSet<TEntity> DbSet { get; set; }

        public GenericRepository(ApplicationDbContext ctx)
        {
            this.dbContext = ctx;
            DbSet = dbContext.Set<TEntity>();
        }

        public List<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }

        public TEntity Get(int id)
        {
            return DbSet.Find(id);
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (!disposed)
            {
                dbContext.Dispose();
                disposed = true;
            }
        }
    }
}