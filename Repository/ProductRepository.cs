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
           => await base.FindByCondition(p => p.Id.Equals(productId), trackChanges).IsInclude(include).SingleOrDefaultAsync();
        public async Task<PagedList<Product>> GetProducts(ProductParameters productPagameters, bool trackChanges = false, string? include = null)
        {
            var products = await base.FindAll(trackChanges)
                                               .SearchByName(productPagameters.Name)
                                               .SearchByBrand(productPagameters.Brand)
                                               .SearchByPrice(productPagameters.Price)
                                               .SearchByUser(new Guid (productPagameters.SellerId!))
                                               .SearchByCategory(new Guid(productPagameters.CategoryId!))
                                               .IsInclude(include)
                                               .ToListAsync();
            return PagedList<Product>.ToPagedList(
                products,
                productPagameters.PageNumber,
                productPagameters.PageSize
  
                );
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
