using RestaurantReservation.Db.Entities;
namespace RestaurantReservation.Db.IRepositories
{
    public interface IMenuItemRepository : IEntityRepository<MenuItem, int>
    {
        Task<List<MenuItem>> ListOrderedMenuItems(int ReservationId);
    }
}