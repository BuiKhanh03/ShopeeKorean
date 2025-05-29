using AutoMapper;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.DataTransferObjects.User;

namespace ShopeeKorean.Application.MappingProfile
{
    public class AuthenticationMappingProfile : Profile
    {
        public AuthenticationMappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles
            .Select(role => new Roles { Name = role }).ToList()));
        }
    }
}
