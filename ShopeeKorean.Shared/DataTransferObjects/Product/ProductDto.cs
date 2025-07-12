using ShopeeKorean.Shared.DataTransferObjects.ProductImage;
using ShopeeKorean.Shared.DataTransferObjects.ProductSize;
using ShopeeKorean.Shared.DataTransferObjects.Review;
using ShopeeKorean.Shared.DataTransferObjects.User;
using ShopeeKorean.Shared.Enums.Status;

namespace ShopeeKorean.Shared.DataTransferObjects.Product
{
    public record ProductDto : BaseDto<ProductDto>    
    {
        public Guid Id { get; set; }
        public Guid SellerId { get; set; }
        public string? SellerName { get; set; }
        public Guid CategoryId { get; set; }
        public string? Categoryname { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public string Brand { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public SystemStatus Status { get; set; } = SystemStatus.Inactive;
        public ICollection<ReviewDto> Reviews { get; set; }
        public ICollection<ProductImageDto> ProductImages { get; set; }
        public ICollection<ProductSizeDto> ProductSizes { get; set; }
    }
}
