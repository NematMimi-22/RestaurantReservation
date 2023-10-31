using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Viewes;
using System.Security.Cryptography;

namespace RestaurantReservation.Db.IRepositories
{
    public interface IReservationRepository : IEntityRepository<Reservation, int>
    {
        Task<List<Reservation>> GetReservationsByReservation(int ReservationId);
        Task<List<ReservationDetailsView>> GetReservationsWithDetailsAsync();
    }
}