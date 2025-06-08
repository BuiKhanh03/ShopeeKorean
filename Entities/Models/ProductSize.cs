namespace ShopeeKorean.Entities.Models
{
    public class ProductSize
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Size { get; set; } = string.Empty;

        public Product Product { get; set; }

    }
}
