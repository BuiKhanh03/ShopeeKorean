using ShopeeKorean.Shared.Enums.Status;

namespace ShopeeKorean.Shared.DataTransferObjects.Shipping
{
    public record ShippingDto : BaseDto<ShippingDto>
    {
        public CarrierStatus Carrier { get; set; } = CarrierStatus.ShopeeExpress;
        public DateTime ShippedAt { get; set; } = DateTime.UtcNow;
        public DateTime DeliveredAt { get; set; } = DateTime.UtcNow;
        public ShippingStatus ShippingStatus { get; set; } = ShippingStatus.Pending;
    }
}
