using AutoMapper;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.DataTransferObjects.Shipping;

namespace ShopeeKorean.Application.MappingProfile
{
    public class ShippingMappingProfile : Profile
    {
        public ShippingMappingProfile()
        {
            CreateMap<Shipping, ShippingForCreationDto>().ReverseMap();
            CreateMap<Shipping, ShippingDto>();
        }
    }
}
