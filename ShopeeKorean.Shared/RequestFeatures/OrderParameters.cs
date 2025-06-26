using ShopeeKorean.Shared.Enums.Status;

namespace ShopeeKorean.Shared.RequestFeatures
{
    public class OrderParameters : RequestParameters
    {
        public OrderParameters() => OrderBy = "CreateAt";

        public decimal TotalAmount { get; set; } = 0;
        public OrderStatus Status { get; set; }
        public decimal ShippingFee { get; set; } = 0;
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;
    }
}
