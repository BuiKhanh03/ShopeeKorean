using ShopeeKorean.Shared.ErrorModel;

namespace ShopeeKorean.Shared.Constant.Order
{
    public class OrderErrors
    {
        #region Error Message
        private static string OrderNotFound = "Order not found with id {0}";
        #endregion
        #region Static Method
        public static ErrorsResult GetOrderNotFound(Guid orderId) => new() { Code= OrderNotFound, Description = string.Format(OrderNotFound, orderId) };
        #endregion
    }
}
