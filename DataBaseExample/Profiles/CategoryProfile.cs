using AutoMapper;
using DataBaseExample.Models;
using DataBaseExample.Dtos;
namespace DataBaseExample.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        { 
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
