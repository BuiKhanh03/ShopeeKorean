using ShopeeKorean.Shared.Enums.Status;

namespace ShopeeKorean.Entities.Models
{
    public class Order : BaseEntity<Order>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? PaymentRecordId { get; set; }
        public Guid? ShippingId { get; set; }
        public decimal TotalAmount {  get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public decimal ShippingFee { get; set; }
        public string ShippingAddress { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; } =    DateTime.UtcNow;
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;
        public User User { get; set; }
        public Shipping Shipping { get; set; }
        public PaymentRecord PaymentRecord { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
