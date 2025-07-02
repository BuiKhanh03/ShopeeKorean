using ShopeeKorean.Shared.DataTransferObjects.OrderItem;
using ShopeeKorean.Shared.DataTransferObjects.PaymentRecord;
using ShopeeKorean.Shared.DataTransferObjects.Shipping;
using ShopeeKorean.Shared.Enums.Status;

namespace ShopeeKorean.Shared.DataTransferObjects.Order
{
    public record OrderDto : BaseDto<OrderDto>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PaymentRecordId { get; set; }
        public Guid ShippingId { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public decimal ShippingFee { get; set; }
        public string ShippingAddress { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;
        public ShippingDto Shipping { get; set; }
        public PaymentRecordDto PaymentRecord { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
