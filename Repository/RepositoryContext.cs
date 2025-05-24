using ShopeeKorean.Entities.Models;
using Microsoft.EntityFrameworkCore;
using ShopeeKorean.Repository.Configuration;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User, Roles, Guid>
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

           foreach(var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName!.StartsWith("AspNet"))
                { 
                    entityType.SetTableName(tableName.Substring(6)); 
                }
            }

            // Configure auto-generation for Guid primary keys
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var keyProperty = entityType.FindPrimaryKey()?.Properties.FirstOrDefault();
                if (keyProperty?.ClrType == typeof(Guid))
                {
                    keyProperty.ValueGenerated = ValueGenerated.OnAdd;
                }
            }

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CartConfiguration());
            builder.ApplyConfiguration(new RolesConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new CouponConfiguration());
            builder.ApplyConfiguration(new ReviewConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new CartItemConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ShippingConfiguration());
            builder.ApplyConfiguration(new OrderItemConfiguration());
            builder.ApplyConfiguration(new ProductImageConfiguration());
            builder.ApplyConfiguration(new PaymentRecordConfiguration());
        }


        public DbSet<Product>? Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PaymentRecord> PaymentRecord { get; set; }
        public DbSet<ProductImage> ProductImages {  get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Cart> Cart { get; set; }
    }
}
