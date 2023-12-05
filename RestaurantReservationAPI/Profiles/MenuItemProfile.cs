using AutoMapper;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservationAPI.Profiles
{
    public class MenuItemProfile : Profile
    {
        public MenuItemProfile()
        {
            CreateMap<MenuItem, MenuItemDTO>();
            CreateMap<MenuItemDTO, MenuItem>()
                .ForMember(dest => dest.MenuItemId, opt => opt.Ignore())
                .ForMember(dest => dest.Restaurant, opt => opt.Ignore()); 
        }
    }
}