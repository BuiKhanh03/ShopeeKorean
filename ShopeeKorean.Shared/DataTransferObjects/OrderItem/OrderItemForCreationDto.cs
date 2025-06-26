namespace ShopeeKorean.Shared.DataTransferObjects.OrderItem
{
    public record OrderItemForCreationDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtTime { get; set; }

    }
}
