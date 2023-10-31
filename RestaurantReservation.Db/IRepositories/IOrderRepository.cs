using RestaurantReservation.Db.Entities;
using System.Security.Cryptography;

namespace RestaurantReservation.Db.IRepositories
{
    public interface IOrderRepository<TId> : IEntityRepository<Order, TId>
    {
        Task<List<Order>> ListOrdersAndMenuItems(TId ReservationId);
    }
}