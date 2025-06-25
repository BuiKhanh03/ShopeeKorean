using AutoMapper;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.DataTransferObjects.CartItemDto;

namespace ShopeeKorean.Application.MappingProfile
{
    public class CartItemMappingProfile : Profile
    {
        public CartItemMappingProfile()
        {
            CreateMap<CartItem, CartItemForGetDto>();
        }
    }
}
