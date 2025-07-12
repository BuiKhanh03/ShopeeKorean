using AutoMapper;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.DataTransferObjects.Product;

namespace ShopeeKorean.Application.MappingProfile
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.SellerName, otps =>
                {
                    otps.PreCondition(otp => otp.Seller != null);
                    otps.MapFrom(src => src.Seller.FirstName + " " + src.Seller.LastName);
                })
                .ForMember(dest => dest.Categoryname, otps =>
                {
                    otps.PreCondition(otp => otp.Category != null);
                    otps.MapFrom(src => src.Category.Name);
                })
                 .ForMember(dest => dest.ProductSizes, opt => opt.MapFrom(src => src.ProductSizes))
                 .ForMember(dest => dest.ProductImages, opt => opt.MapFrom(src => src.ProductImages))
                  .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews))
                .ReverseMap();
            CreateMap<ProductDtoForUpdate, Product>();
            CreateMap<ProductDtoForCreation, Product>();
        }
    }
}
