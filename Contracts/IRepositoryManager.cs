using ShopeeKorean.Repository.Contracts;

namespace ShopeeKorean.Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository UserRepository { get; }
        Task SaveAsync();
    }
}
