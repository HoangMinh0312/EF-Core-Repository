using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCore.Model;
using EFCore.Repo;

namespace EFCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly IRepositoryBase<Product> _repository;

        public ProductsController(IRepositoryBase<Product> repository)
        {
            _repository = repository;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> GetProduct()
        {
            return _repository.FindAll();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public IActionResult GetProduct([FromRoute] int id)
        {
            var product =  _repository.FindByKey(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult PutProduct([FromRoute] int id, [FromBody] Product product)
        {          
            if (id != product.Id)
            {
                return BadRequest();
            }

            _repository.Create(product);
           
            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public  IActionResult PostProduct([FromBody] Product product)
        {
            _repository.Update(product);
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product =  _repository.FindByKey(id);
            if (product == null)
            {
                return NotFound();
            }

            _repository.Delete(product);

            return Ok(product);
        }

        private bool ProductExists(int id)
        {
            return _repository.FindByKey(id)!=null;
        }
    }
}