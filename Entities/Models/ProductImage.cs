namespace ShopeeKorean.Entities.Models
{
    public class ProductImage : BaseEntity<ProductImage>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string? ImageLink { get; set; } = "N/A";
        public string? ImageId { get; set; } = "N/A";
        public bool IsMain {  get; set; }
        public Product Product { get; set; }
    }
}
