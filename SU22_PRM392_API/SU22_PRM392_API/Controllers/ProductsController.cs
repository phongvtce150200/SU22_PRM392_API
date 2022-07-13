using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SU22_PRM392_API.Database;
using SU22_PRM392_API.Models;

namespace SU22_PRM392_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Getproducts()
        {
            return await _context.products.ToListAsync();
        }


        [HttpGet("categoryName")]
        public IActionResult GetProductbyCategory(string categoryName)
        {
            var getCategory = _context.categories.FirstOrDefault(c => c.CategoryName == categoryName);
            if (getCategory == null) return NotFound(new { Response = "Category doesn't exists" });

            var product = _context.products.Where(x => x.CategoryId == getCategory.CategoryId).ToList();
            if (product == null) return NotFound(new { Response = "Category doesn't have product" });


            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string json = JsonConvert.SerializeObject(product, jss);

            return Content(json, "application/json");

            //return Ok(json) ;
            //return Ok(product);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductModelView product)
        {
            Product EditProduct = _context.products.Find(id);

            if (EditProduct == null)
            {
                return BadRequest(new {Response = "Category with Id = " +id+ "not found"});
            }
            else
            {
                /* var checkDuplicate = _context.products.FirstOrDefault(x => x.ProductName == product.ProductName);
                 if (checkDuplicate != null) return BadRequest(new { respone = "Category is already exists" });*/
                EditProduct.ProductName = product.ProductName;
                EditProduct.Description = product.Description;
                EditProduct.Price = product.Price;
                EditProduct.ImagePath = /*$"{RelativeSaveDirectory}{Name}"*/product.Image;
                EditProduct.CategoryId = product.CategoryId;
                _context.Entry(EditProduct).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductModelView product)
        {
            var check = _context.products.FirstOrDefault(x => x.ProductName == product.ProductName);
            if (check != null) return StatusCode(406, new { respone = "Category is already exists" });
            if (string.IsNullOrEmpty(product.ProductName)) return StatusCode(400, new { respone = "Name of category can't be blank" });
            try
            {
                var newProduct = new Product
                {
                    ProductName = product.ProductName,
                    Description = product.Description,
                    Price = product.Price,
                    ImagePath = product.Image,
                    CategoryId = product.CategoryId
                };
                _context.products.Add(newProduct);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return BadRequest();
            }
            return CreatedAtAction("GetProduct", new { id = product.ProductName }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.products.Any(e => e.ProductId == id);
        }
    }
}
