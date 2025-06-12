using ShopeeKorean.Shared.DataTransferObjects.ProductImage;
using ShopeeKorean.Shared.DataTransferObjects.ProductSize;

namespace ShopeeKorean.Shared.DataTransferObjects.Product
{
    public record ProductDtoForCreation : ProductDtoForManipulation
    {
        IEnumerable<ProductSizeDto> ProductSizess { get; set; }
    }
}
