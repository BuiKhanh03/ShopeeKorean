using AutoMapper;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.DataTransferObjects.ProductSize;

namespace ShopeeKorean.Application.MappingProfile
{
    public class ProductServiceMappingProfile : Profile
    {
        public ProductServiceMappingProfile()
        {
            CreateMap<ProductSize, ProductSizeDto>().ReverseMap();
            CreateMap<ProductSizeDtoForUpdate, ProductSize>();
            CreateMap<ProductSizeDtoForCreation, ProductSize>();
        }
    }
}
