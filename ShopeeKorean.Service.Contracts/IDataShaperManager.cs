using ShopeeKorean.Shared.DataTransferObjects.Category;
using ShopeeKorean.Shared.DataTransferObjects.Product;

namespace ShopeeKorean.Service.Contracts
{
    public interface IDataShaperManager
    {
        IDataShaper<CategoryDto> Category { get; }

        IDataShaper<ProductDto> Product { get; }
    }
}
