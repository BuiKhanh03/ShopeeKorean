using ShopeeKorean.Shared.DataTransferObjects.OrderItem;

namespace ShopeeKorean.Shared.DataTransferObjects.Order
{
    public class OrderForCreationDto
    {
        public List<OrderItemForCreationDto> OrderItems { get; set; } = new();
    }
}
