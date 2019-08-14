using EFCore.BaseModel;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public class ExtendPagingRepository<T> : IExtendPagingRepository<T> where T : BaseEntity
    {
        protected DbContext RepositoryContext { get; set; }

        public ExtendPagingRepository(DbContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll(PageRequest<T> pageRequest, params Expression<Func<T, Object>>[] includeExps)
        {
            IQueryable<T> query = RepositoryContext.Set<T>();
            if (pageRequest.HasOrderBy())
            {
                query = pageRequest.OrderBy(query);
            }
           

            if (pageRequest != null && pageRequest != null)
            {
                query = query.Skip((pageRequest.Page - 1) * pageRequest.PageSize).Take(pageRequest.PageSize);
            }
            if (includeExps != null)
                query = includeExps.Aggregate(query, (current, exp) => current.Include(exp));


            return query.AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, PageRequest<T> pageRequest, params Expression<Func<T, Object>>[] includeExps)
        {
            IQueryable<T> query = RepositoryContext.Set<T>().AsQueryable();
            if (pageRequest.HasOrderBy())
            {
                query = pageRequest.OrderBy(query);
            }

            if (expression != null)
            {
                query = query.AsExpandable().Where(expression);
            }

            if (includeExps != null)
                query = includeExps.Aggregate(query, (current, exp) => current.Include(exp));

            if (pageRequest != null && pageRequest != null)
            {
                query = query.Skip((pageRequest.Page - 1) * pageRequest.PageSize).Take(pageRequest.PageSize);
            }

            return query.AsNoTracking();
        }

        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }

        public T FindByKey(int id, params Expression<Func<T, Object>>[] includeExps)
        {
            var query = this.RepositoryContext.Set<T>().AsQueryable();
            if (includeExps != null)
                query = includeExps.Aggregate(query, (current, exp) => current.Include(exp));
            return query.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
