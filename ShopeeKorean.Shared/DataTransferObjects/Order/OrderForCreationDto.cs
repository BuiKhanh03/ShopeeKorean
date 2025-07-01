using ShopeeKorean.Shared.DataTransferObjects.OrderItem;
using ShopeeKorean.Shared.DataTransferObjects.Shipping;

namespace ShopeeKorean.Shared.DataTransferObjects.Order
{
    public class OrderForCreationDto
    {
        public string ShippingAddress { get; set; }
        public decimal ShippingFee { get; set; }
        public ShippingForCreationDto Shipping { get; set; }
        public IEnumerable<OrderItemForCreationDto> OrderItems {  get; set; }
    }
}
