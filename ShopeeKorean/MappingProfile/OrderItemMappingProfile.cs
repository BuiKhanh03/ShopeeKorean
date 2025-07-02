using AutoMapper;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.DataTransferObjects.OrderItem;

namespace ShopeeKorean.Application.MappingProfile
{
    public class OrderItemMappingProfile : Profile
    {
        public OrderItemMappingProfile()
        {
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<OrderItemForCreationDto, OrderItem>();
        }
    }
}
