using AutoMapper;
using backend.DTOs;
using backend.Models;

namespace backend.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Fragrance, FragranceDto>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Gender, GenderDTO>().ReverseMap();
            CreateMap<Sillage, SillageDTO>().ReverseMap();
            CreateMap<Longevity, LongevityDTO>().ReverseMap();
            CreateMap<Scent, ScentDTO>().ReverseMap();
            CreateMap<Season, SeasonDTO>().ReverseMap();
        }
    }
}
