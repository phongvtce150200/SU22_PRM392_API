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
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Getorders()
        {
            return await _context.orders.ToListAsync();
        }

        [HttpGet("{usn}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetUsrOrders(string usn)
        {
            var getUser = await _context.users.FirstOrDefaultAsync(x => x.UserName == usn);
            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string jsons = JsonConvert.SerializeObject(_context.orders.Where(x => x.Id == getUser.Id).ToList(), jss);
            return Content(jsons, "application/json");
        }
        // GET: api/Orders/5
        /*[HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }*/

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       /* [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //Ham nay duoc goi toi khi nguoi dung bam nut checkout
        //Muc dich de luu order va orderDetails vao DB
        //truyen vao username cua thang dang dang nhap
        [HttpPost("{usn}")]
        public async Task<ActionResult> OnGetCheckOut(string usn)
        {
            var getUser = await _context.users.FirstOrDefaultAsync(x => x.UserName == usn);

            var getUsrCart = _context.carts.FirstOrDefault(x => x.Id == getUser.Id);

            var listCart = _context.cartDetails.Where(x => x.CartId == getUsrCart.CartId).ToList();
            if (listCart == null)
            {
                return NotFound(new { Response = "Cart is empty!" });
            }
            DateTime date = DateTime.Now;
            TimeSpan duration = new(7, 0, 0, 0);
            decimal freight = 20000;
            Order order = new Order { Id = getUser.Id, OrderStatus = true, Freight = freight, CreatedDate = date, ShippedDate = date.Add(duration), ShipAddress = getUser.Address };
            order.OrderDetails = new List<OrderDetails>();
            foreach (var item in listCart)
            {
                var GetProd = _context.products.FirstOrDefault(x => x.ProductId == item.ProductId);
                decimal SumTotal = (GetProd.Price * item.Quantity) + freight;
                OrderDetails orderDetails = new() { ProductId = item.ProductId, Quantity = item.Quantity, TotalPrice =  SumTotal};
                order.OrderDetails.Add(orderDetails);
            }
            _context.orders.Add(order);
            _context.SaveChanges();
            var GetUsrOrder = _context.orders.OrderByDescending(x => x.OrderId).FirstOrDefault(x => x.Id == getUser.Id);
            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string jsons = JsonConvert.SerializeObject(_context.orderDetails.Where(x => x.OrderId == GetUsrOrder.OrderId).ToList(), jss);
            //cho nay xu ly xoa cart sau khi user bam thanh toan
            return Content(jsons, "application/json");
        }


        /*// DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.orders.Any(e => e.OrderId == id);
        }*/
    }
}
