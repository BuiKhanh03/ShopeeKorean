using ShopeeKorean.Entities.Models;

namespace ShopeeKorean.Repository.Contracts
{
    public interface IUserRepository
    {
        //string => default = null
        public Task<User?> GetUser(Guid userId, bool trackChanges, string? include = default);
        public Task<User?> GetUser(string mail, bool trackChanges = true, string? include = default);
        public void UpdateUser(User user);
    }
}
