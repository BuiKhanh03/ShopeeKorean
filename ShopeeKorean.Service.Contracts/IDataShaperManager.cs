using ShopeeKorean.Shared.DataTransferObjects.Category;

namespace ShopeeKorean.Service.Contracts
{
    public interface IDataShaperManager
    {
        IDataShaper<CategoryDto> Category { get; }
    }
}
