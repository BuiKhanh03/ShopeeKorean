using Repository;
using ShopeeKorean.Entities.Models;
using Microsoft.EntityFrameworkCore;
using ShopeeKorean.Repository.Contracts;

namespace ShopeeKorean.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

        // base(repositoryContext) { } kế thừa constructor của lớp cha
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        //expression-bodied member (=>) 
        public async Task<User?> GetUser(Guid userId, bool trackChanges, string? include = null)
                     => await FindByCondition(u => u.Id.Equals(userId), trackChanges).SingleOrDefaultAsync();

        public async Task<User?> GetUser(string mail, bool trackChanges = true, string? include = null)
               => await FindByCondition(u => u.Email.Equals(mail), trackChanges).SingleOrDefaultAsync();

        public void UpdateUser(User user)
        {
            Update(user);
        }
    }
}
