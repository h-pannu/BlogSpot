using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Blogger.WebAPI.Data;
using Blogger.WebAPI.DTO.User;
using Blogger.WebAPI.DTO.Category;
using Blogger.Shared.Models;
using Blogger.Shared.DTO;

namespace Blogger.WebAPI.Profiles
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Users, RegisterUserDTO>()
                //.ForMember(dest => dest.FullName, opt=>opt.MapFrom(src=>src.FirstName+" "+ src.LastName))
                .ForMember(dest => dest.StreetAddress, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();

            CreateMap<IdentityRole, CreateRoleDTO>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<Category, CategoryDTO>()
                //.ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<Blog, BlogDTO>()
                //.ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}
