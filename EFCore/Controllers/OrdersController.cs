﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using EFCore.Model;

//namespace EFCore.Controllers
//{
//    [Produces("application/json")]
//    [Route("api/Orders")]
//    public class OrdersController : Controller
//    {
//        private readonly Service1Context _context;

//        public OrdersController(Service1Context context)
//        {
//            _context = context;
//        }

//        // GET: api/Orders
//        [HttpGet]
//        public IEnumerable<Order> GetOrder()
//        {
//            return _context.Order;
//        }

//        // GET: api/Orders/5
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetOrder([FromRoute] int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var order = await _context.Order.SingleOrDefaultAsync(m => m.Id == id);

//            if (order == null)
//            {
//                return NotFound();
//            }

//            return Ok(order);
//        }

//        // PUT: api/Orders/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutOrder([FromRoute] int id, [FromBody] Order order)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != order.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(order).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!OrderExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Orders
//        [HttpPost]
//        public async Task<IActionResult> PostOrder([FromBody] Order order)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            _context.Order.Add(order);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
//        }

//        // DELETE: api/Orders/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var order = await _context.Order.SingleOrDefaultAsync(m => m.Id == id);
//            if (order == null)
//            {
//                return NotFound();
//            }

//            _context.Order.Remove(order);
//            await _context.SaveChangesAsync();

//            return Ok(order);
//        }

//        private bool OrderExists(int id)
//        {
//            return _context.Order.Any(e => e.Id == id);
//        }
//    }
//}