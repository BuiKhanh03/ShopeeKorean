using System.Linq.Dynamic.Core;
using ShopeeKorean.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ShopeeKorean.Repository.Extensions.Utility
{
    public static class CartItemExtensions
    {
        public static IQueryable<CartItem> IsInclude(this IQueryable<CartItem> cartItem, string? fieldsString)
        {
            if (string.IsNullOrEmpty(fieldsString)) return cartItem;
            //Split tách chuỗi thành mảng dựa trên dấu phẩy (',')
            //StringSplitOptions.RemoveEmptyEntries: Bỏ qua các phần tử trống trong kết quả
            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var field in fields)
            {
                /*
                 StringComparison.InvariantCultureIgnoreCase là một giá trị enum thuộc System.StringComparison dùng để so sánh chuỗi không phân biệt hoa thường dựa trên quy tắc văn hóa bất biến (invariant culture).
                */
                var property = CartItem.PropertyInfos.FirstOrDefault(ctg => ctg.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));
                if (property != null)
                    cartItem = cartItem.Include(field);
            }
            return cartItem;
        }

        public static IQueryable<CartItem> Sort(this IQueryable<CartItem> categories, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString)) return categories.OrderBy(p => p.CreatedAt);
            var orderQuery = QueryBuilder.CreateOrderQuery<CartItem>(orderByQueryString, CartItem.PropertyInfos);
            if (string.IsNullOrWhiteSpace(orderQuery)) return categories.OrderBy(ctg => ctg.CreatedAt);
            return categories.OrderBy(orderQuery);
        }
    }
}
