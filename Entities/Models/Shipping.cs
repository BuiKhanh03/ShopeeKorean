using ShopeeKorean.Shared.Enums.Status;

namespace ShopeeKorean.Entities.Models
{
    public class Shipping
    {
        public Guid Id { get; set; }
        public string TrackingNumber {  get; set; } = string.Empty;
        public string Carrier { get; set; } = string.Empty;
        public DateTime ShippedAt {  get; set; } = DateTime.UtcNow;
        public DateTime DeliveredAt {  get; set; } = DateTime.UtcNow;
        public ShippingStatus ShippingStatus { get; set; } = ShippingStatus.Pending;
        public Order Order { get; set; }    
    }
}
