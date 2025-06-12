using ShopeeKorean.Repository.Contracts;

namespace ShopeeKorean.Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IProductSizeRepository ProductSizeRepository { get; }
        IProductImageRepository ProductImageRepository { get; }
        Task SaveAsync();
    }
}
