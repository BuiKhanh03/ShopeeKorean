namespace ShopeeKorean.Entities.Models
{
    public class Review : BaseEntity<Review>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public int Rating { get; set; } 
        public string Comment { get; set; } = string .Empty;

        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

        public Product Product { get; set; }
        public User User { get; set; }

    }
}
