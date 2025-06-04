namespace ShopeeKorean.Entities.Models
{
    public class Category : BaseEntity<Category>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Product Product { get; set; }

    }
}
