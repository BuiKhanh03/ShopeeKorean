using ShopeeKorean.Shared.Enums.Status;

namespace ShopeeKorean.Shared.DataTransferObjects.Shipping
{
    public class ShippingForCreationDto
    {
        public CarrierStatus Carrier { get; set; } = CarrierStatus.ShopeeExpress;
    }
}
