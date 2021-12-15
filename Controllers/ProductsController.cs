using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineMarketPlace.Data;
using OnlineMarketPlace.Models;

namespace OnlineMarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public ProductsController(ProductDbContext context)
        {
            _context = context;
            if(!_context.Product.Any())
            {
                _context.Product.Add(new Product
                {
                    ProductCode = "001",
                    Name = "Lavender heart",
                    Price = "£9.25"
                });

                _context.Product.Add(new Product
                {
                    ProductCode = "002",
                    Name = "Personalised cufflinks",
                    Price = "£45.00"
                });

                _context.Product.Add(new Product
                {
                    ProductCode = "003",
                    Name = "Kids T-shirt",
                    Price = "£19.95"
                });

                _context.SaveChanges();
            }
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Product.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{product_id}")]
        public async Task<ActionResult<Product>> GetProduct(int product_id)
        {
            var product = await _context.Product.FindAsync(product_id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        [HttpPut("{product_id}")]
        public async Task<IActionResult> UpdateProduct(int product_id, Product product)
        {
            if (product_id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product_id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { product_id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{product_id}")]
        public async Task<IActionResult> DeleteProduct(int product_id)
        {
            var product = await _context.Product.FindAsync(product_id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int product_id)
        {
            return _context.Product.Any(e => e.Id == product_id);
        }
    }
}
