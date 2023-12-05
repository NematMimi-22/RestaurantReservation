using AutoMapper;
using RestaurantReservation.Db.Entities;
using RestaurantReservationAPI.DTO;

namespace RestaurantReservationAPI.Profiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItem, OrderItemDTO>();
            CreateMap<OrderItemDTO, OrderItem>()
                .ForMember(dest => dest.OrderItemId, opt => opt.Ignore());
        }
    }
}