using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SU22_PRM392_API.Database;
using SU22_PRM392_API.Models;

namespace SU22_PRM392_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Getcategories()
        {
            return await _context.categories.ToListAsync();
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryModelView category)
        {
            Category EditCate = _context.categories.Find(id);
            if (EditCate == null)
            {
                return BadRequest();
            }
            else
            {
               /* var checkDuplicate = _context.categories.FirstOrDefault(x => x.CategoryName == category.CategoryName);
                if (checkDuplicate != null) return BadRequest(new { respone = "Category is already exists" });*/
                EditCate.CategoryName = category.CategoryName;
                _context.Entry(EditCate).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(id))
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

        // POST: api/Category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(CategoryModelView category)
        {
            var check = _context.categories.FirstOrDefault(x => x.CategoryName == category.CategoryName);
            if (check != null) return StatusCode(406, new { respone = "Category is already exists" });

            if (string.IsNullOrEmpty(category.CategoryName)) return StatusCode(400, new { respone = "Name of category can't be blank" });

            try
            {
                Category item = new Category()
                {
                    CategoryName = category.CategoryName,
                    IsActive = true,
                    CreatedDate = DateTime.Now

                };

                _context.categories.Add(item);
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    Name = item.CategoryName,
                    IsActive = true,
                    CreatedDate = item.CreatedDate.ToShortDateString()
                }); ;
            }
            catch
            {
                return BadRequest(new { respone = "An error handle while processing data, try again" });
            }
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _context.categories.Any(e => e.CategoryId == id);
        }
    }
}
