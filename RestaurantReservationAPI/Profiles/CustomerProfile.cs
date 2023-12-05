using AutoMapper;
using RestaurantReservation.Db.Entities;
using RestaurantReservationAPI.DTO;

namespace RestaurantReservationAPI.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
        }
    }
}