using ShopeeKorean.Shared.DataTransferObjects.CartItemDto;

namespace ShopeeKorean.Shared.DataTransferObjects.Cart
{
    public class CartDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<CartItemForGetDto> CartItems { get; set; }
    }
}
