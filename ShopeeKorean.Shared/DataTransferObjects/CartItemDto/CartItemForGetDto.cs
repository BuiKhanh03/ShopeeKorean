namespace ShopeeKorean.Shared.DataTransferObjects.CartItemDto
{
    public class CartItemForGetDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
