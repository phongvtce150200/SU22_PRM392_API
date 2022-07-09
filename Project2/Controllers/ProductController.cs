using Project2.Database;
using Project2.DTO;
using Project2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace FoodStoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var ProductList = _context.products.ToList();
            return Ok(ProductList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ProductWithId = _context.products.SingleOrDefault(x => x.ProductId == id);
            if (ProductWithId != null)
            {
                return Ok(ProductWithId);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(ProductDTO modelView)
        {

            if (ModelState.IsValid)
            {
/*
                string ext = Path.GetExtension(modelView.Image.FileName);
                List<string> image_extensions = new List<string>() { ".jpg", ".png", "jpeg", ".gif" };
                if (!image_extensions.Contains(ext)) return BadRequest();
                string Name = $"{modelView.ProductName}_{modelView.Image.FileName}";
                //Get url To Save
                string RelativeSaveDirectory = $"/media/{modelView.ProductName}/";
                string AbsoluteSaveFullPath = Directory.GetCurrentDirectory().Replace("\\", "/") + RelativeSaveDirectory + Name;
                if (Directory.Exists(Path.GetDirectoryName(AbsoluteSaveFullPath)) == false)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(AbsoluteSaveFullPath));
                }
                using (FileStream stream = new FileStream(AbsoluteSaveFullPath, FileMode.Create))
                {
                    modelView.Image.CopyTo(stream);
                }*/

                var newProduct = new Product
                {
                    ProductName = modelView.ProductName,
                    Description = modelView.Description,
                    Price = modelView.Price,
                    ImagePath = /*$"{RelativeSaveDirectory}{Name}"*/ modelView.Image,
                    CategoryId = modelView.CategoryId
                };
                _context.Add(newProduct);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("{Id}")]
        public IActionResult EditProduct(int Id, ProductDTO modelView)
        {
            Product EditPro = _context.products.Find(Id);
            var check = _context.products.SingleOrDefault(x => x.ProductId == Id);
            if (check != null)
            {
                if (modelView.Image != null)
                {
                   /* string ext = Path.GetExtension(modelView.Image.FileName);
                    List<string> image_extensions = new List<string>() { ".jpg", ".png", "jpeg", ".gif" };
                    if (!image_extensions.Contains(ext)) return BadRequest();
                    string Name = $"{modelView.ProductName}_{modelView.Image.FileName}";
                    //Get url To Save
                    string RelativeSaveDirectory = $"/media/{modelView.ProductName}/";

                    string AbsoluteSaveFullPath = Directory.GetCurrentDirectory().Replace("\\", "/") + RelativeSaveDirectory + Name;

                    if (Directory.Exists(Path.GetDirectoryName(AbsoluteSaveFullPath)) == false)
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(AbsoluteSaveFullPath));
                    }

                    using (FileStream stream = new FileStream(AbsoluteSaveFullPath, FileMode.Create))
                    {
                        modelView.Image.CopyTo(stream);
                    }*/

                    EditPro.ProductName = modelView.ProductName;
                    EditPro.Description = modelView.Description;
                    EditPro.Price = modelView.Price;
                    EditPro.ImagePath = /*$"{RelativeSaveDirectory}{Name}"*/modelView.Image;
                    EditPro.CategoryId = modelView.CategoryId;
                    _context.products.Update(EditPro);
                    _context.SaveChanges();
                    return Ok();

                }

            }
            else
            {
                return NotFound();
            }
            return BadRequest();
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Product DeleteProducts = _context.products.Find(Id);
            if (DeleteProducts == null)
            {
                return NotFound();
            }
            else
            {
                _context.products.Remove(DeleteProducts);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}

