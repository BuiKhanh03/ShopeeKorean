using Microsoft.EntityFrameworkCore;
using ShopeeKorean.Entities.Models;

namespace ShopeeKorean.Repository.Extensions.Utility
{
    public static class ProductImageExtensions
    {
        public static IQueryable<ProductImage> IsInclude(this IQueryable<ProductImage> productImages, string? fieldsString)
        {
            if(fieldsString == null) return productImages;
            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var field in fields) { 
            var property = ProductImage.PropertyInfos.FirstOrDefault(ctg => ctg.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));
                if (property != null)
                    productImages.Include(field);
            }
            return productImages;
        }
    }
}