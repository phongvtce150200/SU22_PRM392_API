using System;
using System.Collections.Generic;
using System.Linq;
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
    public class CartsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public List<CartDetails> cart;


        public CartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Carts
        //update date: 22/07/2022
        //da fix lai ham Getcarts (get ra list carts cua tung user)
        //them ham delete cart (dung khi user bam thanh toan hoac su dung cho muc dich khac)
        //chua biet cach goi ham delete tu cartscontroller qua orderscontroller
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartDetails>>> Getcarts(string usn)
        {
            var getUser = await _context.users.FirstOrDefaultAsync(x => x.UserName == usn);
            
            var getCart = _context.carts.FirstOrDefault(x => x.Id == getUser.Id);
            if(getCart == null)
            {
                Cart cart = new Cart { Id = getUser.Id, CartStatus = true, CreatedDate = DateTime.UtcNow };
                _context.SaveChanges();
            }
            var GetCartList = _context.cartDetails.Where(x => x.CartId == getCart.CartId);
            if (GetCartList == null)
                return null;
            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string jsons = JsonConvert.SerializeObject(GetCartList, jss);
            return Content(jsons, "application/json");
        }

        //da fix lai ham OnGetAddToCart show ra dung list carts cua user
        [HttpPost("{id}")]
        public async Task<ActionResult> OnGetAddToCart(int id, string usn)
        {
            var getUser = await _context.users.FirstOrDefaultAsync(x => x.UserName == usn);
            var getCart = _context.carts.FirstOrDefault(x => x.Id == getUser.Id);

            if (getCart == null)
            {
                var GetProd = _context.products.FirstOrDefault(x => x.ProductId == id);
                Cart cart = new Cart { Id = getUser.Id, CartStatus = true, CreatedDate = DateTime.UtcNow };
                _context.carts.Add(cart);
                _context.SaveChanges();
                CartDetails cartDetails = new CartDetails { CartId = cart.CartId, ProductId = id, Quantity = 1, Product = GetProd };
                _context.cartDetails.Add(cartDetails);
                _context.SaveChanges();
                JsonSerializerSettings jss = new JsonSerializerSettings();
                jss.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                string jsons = JsonConvert.SerializeObject(cartDetails, jss);
                return Content(jsons, "application/json");
            }
            var pod = new Product();
            int index = Exists(_context.cartDetails.Where(x => x.CartId == getCart.CartId).ToList(), id);
            if (index == -1)
            {
                var getProd = _context.products.FirstOrDefault(x => x.ProductId == id);
                var getCartObj = _context.carts.FirstOrDefault(x => x.Id == getUser.Id);
                CartDetails cartDetails1 = new CartDetails { CartId = getCartObj.CartId, ProductId = id, Quantity = 1, Product = getProd };
                _context.cartDetails.Add(cartDetails1);
                _context.SaveChanges();
            }
            else
            {
                var abc = _context.cartDetails.Where(x => x.CartId == getCart.CartId).FirstOrDefault(x => x.ProductId == id);
                if (abc != null)
                {
                    abc.Quantity++;
                    _context.cartDetails.Update(abc);
                    _context.SaveChanges();
                }
            }

            JsonSerializerSettings jsss = new JsonSerializerSettings();
            jsss.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string json = JsonConvert.SerializeObject(_context.cartDetails.Where(x => x.CartId == getCart.CartId).ToList(), jsss);
            return Content(json, "application/json");
        }

        /*[HttpPost("{id}")]
        public async Task<IActionResult> OnGetIncrease(int id, string usn)
        {
            var getItem = _context.cartDetails.FirstOrDefault(x => x.ProductId == id);
            if (getItem != null)
            {
                getItem.Quantity++;
                _context.cartDetails.Update(getItem);
                await _context.SaveChangesAsync();
            }
            JsonSerializerSettings jsss = new JsonSerializerSettings();
            jsss.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string json = JsonConvert.SerializeObject(_context.cartDetails.ToList(), jsss);
            return Content(json, "application/json");
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> OnGetDecrease(int id, string usn)
        {
            var getItem = _context.cartDetails.FirstOrDefault(x => x.ProductId == id);
            if (getItem != null)
            {
                if (getItem.Quantity > 1)
                {
                    getItem.Quantity--;
                    _context.cartDetails.Update(getItem);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.cartDetails.Remove(getItem);
                    await _context.SaveChangesAsync();
                }
            }
            JsonSerializerSettings jsss = new JsonSerializerSettings();
            jsss.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string json = JsonConvert.SerializeObject(_context.cartDetails.ToList(), jsss);
            return Content(json, "application/json");
        }*/
        
        // DELETE: api/Orders/5
        [HttpDelete("{usn}")]
        public async Task<IActionResult> DeleteUsrCart(string usn)
        {
            var getUser = await _context.users.FirstOrDefaultAsync(x => x.UserName == usn);
            var cart = _context.carts.FirstOrDefault(x => x.Id == getUser.Id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.carts.Remove(cart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private int Exists(List<CartDetails> cart, int id)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].ProductId == id)
                    return i;
            }
            return -1;
        }
    }
}
