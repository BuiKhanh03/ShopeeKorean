using System.Linq.Dynamic.Core;
using ShopeeKorean.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ShopeeKorean.Repository.Extensions.Utility
{
    public static class CategoryRepositoryExtensions
    {
        //IQueryable: LINQ (Language Integrated Query) để thực hiện các truy vấn dữ liệu
        public static IQueryable<Category> SearchByName(this IQueryable<Category> category, string? name)
        {
            if (string.IsNullOrEmpty(name)) return category;
            return category.Where(x => x.Name.ToLower().Contains(name.ToLower()));
        }

        public static IQueryable<Category> IsInclude(this IQueryable<Category> category, string? fieldsString)
        {
            if(string.IsNullOrEmpty(fieldsString)) return category;
            //Split tách chuỗi thành mảng dựa trên dấu phẩy (',')
            //StringSplitOptions.RemoveEmptyEntries: Bỏ qua các phần tử trống trong kết quả
            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var field in fields) {
                /*
                 StringComparison.InvariantCultureIgnoreCase là một giá trị enum thuộc System.StringComparison dùng để so sánh chuỗi không phân biệt hoa thường dựa trên quy tắc văn hóa bất biến (invariant culture).
                */
                var property = Category.PropertyInfos.FirstOrDefault(ctg => ctg.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));
                if (property != null)
                    category = category.Include(field);
            }
            return category;
        }

        public static IQueryable<Category> Sort(this IQueryable<Category> categories, string? orderByQueryString)
        { 
            if (string.IsNullOrWhiteSpace(orderByQueryString)) return categories.OrderBy(p => p.Name);
            var orderQuery = QueryBuilder.CreateOrderQuery<Category>(orderByQueryString, Category.PropertyInfos);
            if(string.IsNullOrWhiteSpace(orderQuery)) return categories.OrderBy(ctg => ctg.Name);
            return categories.OrderBy(orderQuery);
        }
    }
}
