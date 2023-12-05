using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Viewes;

namespace RestaurantReservation.Db.IRepositories
{
    public interface IReservationRepository : IEntityRepository<Reservation, int>
    {
        Task<List<Reservation>> GetReservationsByReservation(int ReservationId);
        Task<List<ReservationDetailsView>> GetReservationsWithDetailsAsync();
        Task<IEnumerable<Reservation>> GetReservationsByCustomerAsync(int customerId);
        Task<IEnumerable<Order>> GetOrdersForReservationAsync(int reservationId);
        Task<IEnumerable<MenuItem>> GetMenuItemsForReservationAsync(int reservationId);
    }
}