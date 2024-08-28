using AutoMapper;
using backend.DTOs;
using backend.DTOs.UserDTOs;
using backend.Models;

namespace backend.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Fragrance, FragranceDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Gender, GenderDTO>().ReverseMap();
            CreateMap<Sillage, SillageDTO>().ReverseMap();
            CreateMap<Longevity, LongevityDTO>().ReverseMap();
            CreateMap<Scent, ScentDTO>().ReverseMap();
            CreateMap<Season, SeasonDTO>().ReverseMap();

            CreateMap<Cart, CartDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<CartItem, CartItemDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();

        }
    }
}
