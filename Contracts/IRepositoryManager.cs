using ShopeeKorean.Repository.Contracts;

namespace ShopeeKorean.Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository UserRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        IProductImageRepository ProductImageRepository { get; }
        IProductRepository ProductRepository { get; }
        Task SaveAsync();
    }
}
