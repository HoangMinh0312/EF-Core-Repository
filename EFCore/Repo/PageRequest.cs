using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public class SortObject<TEntity>
    {
        public IOrderedQueryable<TEntity> Orders {get; set; }        
    } 

    public class PageRequest<TEntity>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy { get; set; }


        public void SetOrderBy(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            OrderBy = orderBy;
        }

        public bool HasOrderBy()
        {
            return OrderBy != null;
        }
    }
}
