using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T FindByKey(int id);

    }

    public interface IPagingBase<T>
    {
        IQueryable<T> FindAll(PageRequest<T> pageRequest);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, PageRequest<T> pageRequest);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T FindByKey(int id);
    }

    public interface IExtendPagingRepository<T>
    {
        IQueryable<T> FindAll(PageRequest<T> pageRequest, params Expression<Func<T, Object>>[] includeExps);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, PageRequest<T> pageRequest, params Expression<Func<T, Object>>[] includeExps);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T FindByKey(int id, params Expression<Func<T, Object>>[] includeExps);
    }
}
