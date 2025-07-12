using ShopeeKorean.Shared.DataTransferObjects.ProductImage;
using ShopeeKorean.Shared.DataTransferObjects.ProductSize;

namespace ShopeeKorean.Shared.DataTransferObjects.Product
{
    public class  ProductDtoForCreation 
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Brand { get; set; } = string.Empty;
        public IEnumerable<ProductSizeDtoForCreation> ProductSizes { get; set; } 
    }
}
