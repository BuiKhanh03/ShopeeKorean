using AutoMapper;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.DataTransferObjects.ProductImage;

namespace ShopeeKorean.Application.MappingProfile
{
    public class ProductImageMappingProfile : Profile
    {
        public ProductImageMappingProfile()
        {
            CreateMap<ProductImage, ProductImageDto>();
            CreateMap<ProductImageDtoForCreation, ProductImage>();
            CreateMap<ProductImageDtoForUpdate, ProductImage>();
        }
    }
}
