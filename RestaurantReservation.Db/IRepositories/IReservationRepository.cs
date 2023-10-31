using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Viewes;
using System.Security.Cryptography;

namespace RestaurantReservation.Db.IRepositories
{
    public interface IReservationRepository<TId> : IEntityRepository<Reservation, TId>
    {
        Task<List<Reservation>> GetReservationsByReservation(TId ReservationId);
        Task<List<ReservationDetailsView>> GetReservationsWithDetailsAsync();
    }
}