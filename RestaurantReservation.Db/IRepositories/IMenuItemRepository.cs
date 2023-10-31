using RestaurantReservation.Db.Entities;
namespace RestaurantReservation.Db.IRepositories
{
    public interface IMenuItemRepository<TId> : IEntityRepository<MenuItem, TId>
    {
        Task<List<MenuItem>> ListOrderedMenuItems(TId ReservationId);
    }
}