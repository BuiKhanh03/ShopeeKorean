
using Repository;
using ShopeeKorean.Contracts;

namespace ShopeeKorean.Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
