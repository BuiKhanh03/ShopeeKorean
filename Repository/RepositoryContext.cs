using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopeeKorean.Entities.Models;
namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User, Roles, Guid>
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }
        public DbSet<Product>? Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentRecord> PaymentRecord { get; set; }
        public DbSet<ProductImage> ProductImages {  get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
    }
}
