using Repository;
using ShopeeKorean.Entities.Models;
using Microsoft.EntityFrameworkCore;
using ShopeeKorean.Repository.Contracts;
using ShopeeKorean.Shared.RequestFeatures;
using ShopeeKorean.Repository.Extensions.Utility;

namespace ShopeeKorean.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base (repositoryContext)
        {
            
        }
        public async Task CreateProduct(Product product) => await base.CreateAsync(product);

        public async Task<Product?> GetProduct(Guid productId, bool trackChanges = false, string? include = null)
        {
            var product = await base.FindByCondition(p => p.Id.Equals(productId), trackChanges).IsInclude(include).Include(p => p.Reviews)
        .ThenInclude(r => r.User).SingleOrDefaultAsync();
            return product;
        }
        public async Task<PagedList<Product>> GetProducts(ProductParameters productPagameters, bool trackChanges = false, string? include = null)
        {
            Guid? sellerGuid = Guid.TryParse(productPagameters.SellerId, out var sId) ? sId : (Guid?)null;
            Guid? categoryGuid = Guid.TryParse(productPagameters.CategoryId, out var cId) ? cId : (Guid?)null;

            var query = base.FindAll(trackChanges)
                            .SearchByName(productPagameters.Name)
                            .SearchByBrand(productPagameters.Brand)
                            .SearchByPrice(productPagameters.Price);

            if (sellerGuid.HasValue)
                query = query.SearchByUser(sellerGuid.Value);

            if (categoryGuid.HasValue)
                query = query.SearchByCategory(categoryGuid.Value);

            var products = await query.IsInclude(include).Include(p => p.Reviews)
        .ThenInclude(r => r.User).ToListAsync();

            return PagedList<Product>.ToPagedList(
                products,
                productPagameters.PageNumber,
                productPagameters.PageSize

                );
        }

        public async Task<PagedList<Product>> GetProducts(Guid userId, ProductParameters productPagameters, bool trackChanges = false, string? include = null)
        {
            var products = await FindByCondition(p => p.SellerId.Equals(userId), trackChanges).IsInclude(include).ToListAsync();
            return PagedList<Product>.ToPagedList(
               products,
               productPagameters.PageNumber,
               productPagameters.PageSize

               );
        }

        public void UpdateProduct(Product product)
        {
            base.Update(product);
        }
    }
}
