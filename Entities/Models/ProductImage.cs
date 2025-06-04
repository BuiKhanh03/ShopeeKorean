namespace ShopeeKorean.Entities.Models
{
    public class ProductImage : BaseEntity<ProductImage>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsMain {  get; set; }
        public Product Product { get; set; }
    }
}
