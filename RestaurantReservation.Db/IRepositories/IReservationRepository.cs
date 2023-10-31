using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Viewes;

namespace RestaurantReservation.Db.IRepositories
{
    public interface IReservationRepository : IEntityRepository<Reservation>
    {
        Task<List<Reservation>> GetReservationsByReservation(int ReservationId);
        Task<List<ReservationDetailsView>> GetReservationsWithDetailsAsync();
    }
}