using ShopeeKorean.Shared.Enums;

namespace ShopeeKorean.Entities.Models
{
    public class Coupon : BaseEntity<Coupon>
    {
        public Guid Id
        {
            get; set;
        }
        public Guid ProductId { get; set; }
        public string Code { get; set; } = string.Empty; 
        public CouponType Type { get; set; } = CouponType.Percentage; 
        public decimal Value
        {
            get; set;
        }
        public decimal MaxDiscount
        {
            get; set;
        }
        public decimal MinOrderValue
        {
            get; set;
        }
        public DateTime ValidFrom
        {
            get; set;
        }
        public DateTime ValidUntil
        {
            get; set;
        }
        public int UsageLimit
        {
            get; set;
        }
        public int UsedCount { get; set; } = 0;

        public string? ImageLink { get; set; } = "N/A";
        public string? ImageId { get; set; } = "N/A";

        public Product Product { get; set; }
    }
}