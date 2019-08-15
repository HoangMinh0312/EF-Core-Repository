using EFCore.Model;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Controllers
{
    [Produces("application/json")]
    [Route("api/ProductsExtend")]
    public class ProductsExtendController : Controller
    {
        private readonly IExtendPagingRepository<Product> _repository;

        public ProductsExtendController(IExtendPagingRepository<Product> repository)
        {
            _repository = repository;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> GetProduct(int pageIndex, int pageSize)
        {
            Func<IQueryable<Product>, IOrderedQueryable<Product>> orders = x => x.OrderByDescending(y => y.Id);
            return _repository.FindAll(new PageRequest<Product> { Page = 1, PageSize = 5, OrderBy = orders }, x => x.Supplier);
        }
    }
}
