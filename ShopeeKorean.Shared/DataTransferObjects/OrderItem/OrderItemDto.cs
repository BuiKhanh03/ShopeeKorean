﻿namespace ShopeeKorean.Shared.DataTransferObjects.OrderItem
{
    public class OrderItemDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtTime { get; set; }

    }
}
