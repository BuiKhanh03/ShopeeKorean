using AutoMapper;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.DataTransferObjects.CartItemDto;
using ShopeeKorean.Shared.DataTransferObjects.Review;

namespace ShopeeKorean.Application.MappingProfile
{
    public class ReviewMappingProfile : Profile
    {
        public ReviewMappingProfile()
        {
            CreateMap<Review, ReviewDto>()
                  .ForMember(dest => dest.UserName, otps =>
                  {
                      otps.PreCondition(otp => otp.User != null);
                      otps.MapFrom(src => src.User.FirstName + " " + src.User.LastName);
                  })
                    .ForMember(dest => dest.UserImageUrl, otps =>
                    {
                        otps.PreCondition(otp => otp.User != null);
                        otps.MapFrom(src => src.User.ImageLink);
                    });
            CreateMap<ReviewForCreationDto, Review>();
            CreateMap<ReviewForUpdateDto, Review>();
        }
    }
    }
