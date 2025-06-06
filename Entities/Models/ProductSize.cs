namespace ShopeeKorean.Entities.Models
{
    public class ProductSize
    {
        public Guid Id { get; set; }
        public Guid productId { get; set; }
        public string size { get; set; } = string.Empty;

    }
}
