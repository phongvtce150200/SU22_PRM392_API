using Microsoft.EntityFrameworkCore;
using SU22_PRM392_API.Models;

namespace SU22_PRM392_API.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<CartDetails> cartDetails { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OrderDetails>().HasKey(x => new { x.OrderId, x.ProductId });
            builder.Entity<CartDetails>().HasKey(x => new { x.CartId, x.ProductId });
        }
    }
}
