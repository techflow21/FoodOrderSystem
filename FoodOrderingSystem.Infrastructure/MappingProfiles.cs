using AutoMapper;
using FoodOrderingSystem.Core.DTOs;
using FoodOrderingSystem.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace FoodOrderingSystem.Infrastructure
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, RegisterDto>().ReverseMap();
            CreateMap<IdentityRole, RoleDto>().ReverseMap();
            CreateMap<Contact, ContactRequestDto>().ReverseMap();
            CreateMap<Reservation, ReservationRequestDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            /*CreateMap<ProductModel, ProductViewModel>().ReverseMap();
            CreateMap<CategoryModel, CategoryViewModel>().ReverseMap();
            CreateMap<CartModel, CartViewModel>().ReverseMap();
            CreateMap<CartItemModel, CartItemViewModel>().ReverseMap();*/
        }
    }
}
