using System.Linq.Dynamic.Core;
using ShopeeKorean.Entities.Models;
using Microsoft.EntityFrameworkCore;
using ShopeeKorean.Shared.Enums.Status;

namespace ShopeeKorean.Repository.Extensions.Utility
{
    public static class OrderExtensions
    {
        public static IQueryable<Order> SearchByTotalAmount(this IQueryable<Order> order, decimal totalAmount)
        {
            if (totalAmount == 0) return order;
            return order.Where(x => x.TotalAmount == totalAmount);
        }

        public static IQueryable<Order> SearchByPayment(this IQueryable<Order> order, Guid? paymentId)
        {
            if (paymentId == null) return order;
            return order.Where(x => x.PaymentRecord.Id.Equals(paymentId));
        }

        public static IQueryable<Order> SearchByStatus(this IQueryable<Order> order, OrderStatus status)
        {
            if (status == null || status == 0)
                return order;
            return order.Where(x => x.Status == status);
        }

        public static IQueryable<Order> SearchByShippingFee(this IQueryable<Order> order, decimal shippingFee)
        {
            if (shippingFee == 0) return order;
            return order.Where(x => x.ShippingFee == shippingFee);
        }

        public static IQueryable<Order> SearchByCreateAt(this IQueryable<Order> orders, DateTimeOffset? createdAt)
        {
            if (createdAt == null)
                return orders;

            return orders.Where(x => x.CreateAt.Date == createdAt.Value.Date);
        }

        public static IQueryable<Order> SearchByUpdatedAt(this IQueryable<Order> orders, DateTimeOffset? updatedAt)
        {
            if (updatedAt == null)
                return orders;

            return orders.Where(x => x.UpdateAt.Date == updatedAt.Value.Date);
        }


        public static IQueryable<Order> IsInclude(this IQueryable<Order> order, string? fieldsString)
        {
            if (string.IsNullOrEmpty(fieldsString)) return order;
            //Split tách chuỗi thành mảng dựa trên dấu phẩy (',')
            //StringSplitOptions.RemoveEmptyEntries: Bỏ qua các phần tử trống trong kết quả
            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var field in fields)
            {
                /*
                 StringComparison.InvariantCultureIgnoreCase là một giá trị enum thuộc System.StringComparison dùng để so sánh chuỗi không phân biệt hoa thường dựa trên quy tắc văn hóa bất biến (invariant culture).
                */
                var property = Order.PropertyInfos.FirstOrDefault(ctg => ctg.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));
                if (property != null)
                    order = order.Include(field);
            }
            return order;
        }

        public static IQueryable<Order> Sort(this IQueryable<Order> categories, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString)) return categories.OrderBy(p => p.CreateAt);
            var orderQuery = QueryBuilder.CreateOrderQuery<Order>(orderByQueryString, Order.PropertyInfos);
            if (string.IsNullOrWhiteSpace(orderQuery)) return categories.OrderBy(ctg => ctg.CreateAt);
            return categories.OrderBy(orderQuery);
        }
    }
}
