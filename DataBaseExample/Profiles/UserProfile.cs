using AutoMapper;
using DataBaseExample.Dtos;
using DataBaseExample.Models;
namespace DataBaseExample.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<User, UserOutputDto>();
            CreateMap<UserOutputDto, User>();
            CreateMap<User, AddUserDto>();
            CreateMap<AddUserDto, User>();


        }

    }
}
