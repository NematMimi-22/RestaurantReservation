using RestaurantReservation.Db.Entities;
namespace RestaurantReservation.Db.IRepositories
{
    public interface IOrderRepository : IEntityRepository<Order>
    {
        Task<List<Order>> ListOrdersAndMenuItems(int ReservationId);
    }
}