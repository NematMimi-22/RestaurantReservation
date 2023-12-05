using AutoMapper;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservationAPI.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>()
                .ForMember(dest => dest.OrderId, opt => opt.Ignore())
                .ForMember(dest => dest.Reservation, opt => opt.Ignore())
                .ForMember(dest => dest.Employee, opt => opt.Ignore());
        }
    }
}