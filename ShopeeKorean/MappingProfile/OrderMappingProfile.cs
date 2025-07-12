using AutoMapper;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.DataTransferObjects.Order;
using ShopeeKorean.Shared.DataTransferObjects.OrderItem;

namespace ShopeeKorean.Application.MappingProfile
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderForCreationDto>().ReverseMap();
           CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderDto, Order>();
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<OrderItemForCreationDto, OrderItem>();
        }
    }
}
