namespace ShopeeKorean.Entities.Models
{
    public class CartItem : BaseEntity<CartItem>
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
