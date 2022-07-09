using Project2.Database;
using Project2.DTO;
using Project2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Controllers
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

        [HttpGet]
        public IActionResult GetAll()
        {
            var cat = _context.categories.ToList();
            return Ok(cat);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            var CategoriesWithId = await _context.categories.FirstOrDefaultAsync(find => find.CategoryId.ToString() == Id);

            if (CategoriesWithId == null) return NotFound(new { respone = "Can't not found" });


            return Ok(CategoriesWithId);

        }

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string byName)
        {
            var CategoriesWithName = await _context.categories.FirstOrDefaultAsync(find => find.CategoryName == byName);

            if (CategoriesWithName == null) return NotFound(new { respone = "Can't not found" });


            return Ok(CategoriesWithName);

        }

        [HttpPost]
        public async Task<IActionResult> CreateNew(CategoryDTO model)
        {
            var check = _context.categories.FirstOrDefault(x => x.CategoryName == model.CategoryName);
            if (check != null) return StatusCode(406, new { respone = "Category is already exists" });

            if (string.IsNullOrEmpty(model.CategoryName)) return StatusCode(400, new { respone = "Name of category can't be blank" });

            try
            {
                Category item = new Category()
                {
                    CategoryName = model.CategoryName,
                    IsActive = true,
                    CreatedDate = DateTime.Now

                };
                _context.Add(item);
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

        [HttpPut("{Id}")]
        public IActionResult EditCategories(int Id, CategoryDTO modelView)
        {
            Category EditCate = _context.categories.Find(Id);
            var check = _context.categories.SingleOrDefault(x => x.CategoryId == Id);
            if (check != null)
            {
                var checkDuplicate = _context.categories.FirstOrDefault(x => x.CategoryName == modelView.CategoryName);
                if (checkDuplicate != null) return BadRequest(new { respone = "Category is already exists" });
                EditCate.CategoryName = modelView.CategoryName;
                _context.categories.Update(EditCate);
                _context.SaveChanges();
                return Ok(new { respone = "Update successfully" });
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            Category DeleteCategories = await _context.categories.FindAsync(Id);
            if (DeleteCategories == null) return NotFound(new { respone = "Category not found" });

            try
            {
                _context.categories.Remove(DeleteCategories);
                await _context.SaveChangesAsync();
                return Ok(new { respone = "Category delete succesfully" });
            }
            catch
            {
                return BadRequest(new { respone = "Unhandle Error" });
            }
        }


    }
}
