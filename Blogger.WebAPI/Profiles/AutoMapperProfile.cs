using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Blogger.WebAPI.Data;
using Blogger.WebAPI.DTO;

namespace Blogger.WebAPI.Profiles
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Users, RegisterUserDTO>()
                .ForMember(dest => dest.FullName, opt=>opt.MapFrom(src=>src.FirstName+" "+ src.LastName))
                .ForMember(dest => dest.StreetAddress, opt => opt.MapFrom(src => src.Address))
                .ReverseMap();

            CreateMap<IdentityRole, CreateRoleDTO>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}
