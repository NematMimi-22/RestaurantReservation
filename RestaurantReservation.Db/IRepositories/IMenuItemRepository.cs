using RestaurantReservation.Db.Entities;
namespace RestaurantReservation.Db.IRepositories
{
    public interface IMenuItemRepository : IEntityRepository<MenuItem>
    {
        Task<List<MenuItem>> ListOrderedMenuItems(int ReservationId);
    }
}