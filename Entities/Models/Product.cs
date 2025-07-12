using ShopeeKorean.Shared.Enums.Status;

namespace ShopeeKorean.Entities.Models
{
    public class Product : BaseEntity<Product>
    {
        public Guid Id { get; set; }
        public Guid SellerId { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Brand { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public SystemStatus Status { get; set; } = SystemStatus.Active;
        public virtual User Seller { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; } = new List<OrderItem> { };
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem> { };
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        public ICollection<Coupon> Coupons { get; set; } = new List<Coupon>();
        public ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
    }
}
