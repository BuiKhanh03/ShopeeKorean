namespace ShopeeKorean.Entities.Models
{
    public class Category : BaseEntity<Category>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ImageLink { get; set; } = "N/A";
        public string? ImageId { get; set; } = "N/A";
        public Product Product { get; set; }

    }
}
