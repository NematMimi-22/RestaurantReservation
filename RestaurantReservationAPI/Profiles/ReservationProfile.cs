using AutoMapper;
using RestaurantReservation.Db.Entities;
using RestaurantReservationAPI.DTO;

namespace RestaurantReservationAPI.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationDTO>();
            CreateMap<ReservationDTO, Reservation>()
                .ForMember(dest => dest.ReservationId, opt => opt.Ignore()); // Ignore mapping ReservationId during update
        }
    }
}