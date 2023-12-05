using AutoMapper;
using RestaurantReservation.Db.Entities;

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