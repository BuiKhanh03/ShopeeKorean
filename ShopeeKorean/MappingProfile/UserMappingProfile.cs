using AutoMapper;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.DataTransferObjects.User;

namespace ShopeeKorean.Application.MappingProfile
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() { 
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<UserForUpdateDto, User>();
        }
    }
}
