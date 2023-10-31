using RestaurantReservation.Db.Entities;
using System.Security.Cryptography;

namespace RestaurantReservation.Db.IRepositories
{
    public interface IOrderRepository : IEntityRepository<Order, int>
    {
        Task<List<Order>> ListOrdersAndMenuItems(int ReservationId);
    }
}