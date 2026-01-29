using AutoMapper;
using MusmulogullariMarket.Application.DTOs.Categories;
using MusmulogullariMarket.Domain.Entities;

namespace MusmulogullariMarket.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
        }
    }
}