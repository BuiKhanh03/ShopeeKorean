using ShopeeKorean.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ShopeeKorean.Repository.Extensions.Utility
{
    public static class ProductRepositoryExtensions
    {

        public static IQueryable<Product> SearchByName(this IQueryable<Product> products, string? name)
        {
            if (string.IsNullOrEmpty(name)) return products;
            return products.Where(p => p.Name.ToLower().Equals(name.ToLower().Trim()));
        }
        
        public static IQueryable<Product> SearchByBrand(this IQueryable<Product> products, string? brand)
        {
            if (string.IsNullOrEmpty(brand)) return products;
            return products.Where(p => p.Brand.ToLower().Equals(brand.ToLower().Trim()));
        }

        public static IQueryable<Product> SearchByPrice(this IQueryable<Product> products, decimal price = 0)
        {
            if (price == 0) return products;
            return products.Where(p => p.Price == price); 
        }

        public static IQueryable<Product> SearchByUser(this IQueryable<Product> products, Guid? userId)
        {
            if(userId == null) return products;
            return products.Where(p => p.SellerId.Equals(userId.Value));
        }

        public static IQueryable<Product> SearchByCategory(this IQueryable<Product> products, Guid? categoryId)
        {
            if(categoryId == null) return products;
            return products.Where(p => p.CategoryId.Equals(categoryId));
        }

        public static IQueryable<Product> IsInclude(this IQueryable<Product> product, string? fieldsName)
        {
            if (string.IsNullOrWhiteSpace(fieldsName)) return product;
            var fields = fieldsName.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in fields)
            {
                var property = Product.PropertyInfos.FirstOrDefault(cp => cp.Name.Equals(item.Trim(), StringComparison.InvariantCultureIgnoreCase));
                if (property != null) product.Include(item.Trim());
            }
            return product; 
        }
    }
}
