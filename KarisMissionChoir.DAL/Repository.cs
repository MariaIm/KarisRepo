using KarisMissionChoir.Contract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KarisMissionChoir.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected KarisMissionChoirContext Context;
        protected DbSet<TEntity> DbSet;

        public Repository(KarisMissionChoirContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual void Insert(TEntity entityToInsert)
        {
            if (Context.Entry(entityToInsert).State != EntityState.Detached)
                Context.Entry(entityToInsert).State = EntityState.Added;
            else
                DbSet.Add(entityToInsert);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            if (Context.Entry(entityToUpdate).State == EntityState.Detached)
                DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            Delete(entity);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State != EntityState.Deleted)
                Context.Entry(entityToDelete).State = EntityState.Deleted;
            else
            {
                DbSet.Attach(entityToDelete);
                DbSet.Remove(entityToDelete);
            }
        }
    }
}
