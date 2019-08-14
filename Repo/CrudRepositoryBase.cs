using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public  class CrudRepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        protected DbContext RepositoryContext { get; set; }

        public CrudRepositoryBase(DbContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public virtual IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public virtual void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
            RepositoryContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
            RepositoryContext.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
            RepositoryContext.SaveChanges();
        }

        public virtual T FindByKey(int id)
        {
            return this.RepositoryContext.Set<T>().Find(id);
        }

        public virtual DbSet<T> DbSet()
        {
            return this.RepositoryContext.Set<T>();
        }
    }
}
