

namespace ShopeeKorean.Shared.DataTransferObjects.CartItemDto
{
    public record CartItemForCreationDto : CartItemManipulationDto
    {
        public Guid ProductId { get; set; }
    }
}
