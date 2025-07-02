using ShopeeKorean.Shared.DataTransferObjects.OrderItem;
using ShopeeKorean.Shared.DataTransferObjects.PaymentRecord;
using ShopeeKorean.Shared.DataTransferObjects.Shipping;

namespace ShopeeKorean.Shared.DataTransferObjects.Order
{
    public class OrderForCreationDto
    {
        public string ShippingAddress { get; set; }
        public decimal ShippingFee { get; set; } = 10000;
        public PaymentRecordForCreationDto PaymentRecord { get; set; }
        public ShippingForCreationDto Shipping { get; set; }
        public IEnumerable<OrderItemForCreationDto> OrderItems {  get; set; }
    }
}
