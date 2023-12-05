using AutoMapper;
using RestaurantReservation.Db.Entities;
using RestaurantReservationAPI.DTO;

namespace RestaurantReservationAPI.Profiles
{
    public class TableProfile : Profile
    {
        public TableProfile()
        {
            CreateMap<Table, TableDTO>();
            CreateMap<TableDTO, Table>()
                .ForMember(dest => dest.TableId, opt => opt.Ignore());
        }
    }
}