using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.IRepositories;
using RestaurantReservation.Repositories;
public class MenuItemRepository : EntityRepositoryBase<MenuItem, int>, IMenuItemRepository
{
    public MenuItemRepository(DbContextOptions<RestaurantReservationDbContext> dbContextOptions)
        : base(new RestaurantReservationDbContext(dbContextOptions))
    {
    }

    public async Task<List<MenuItem>> ListOrderedMenuItems(int ReservationId)
    {
        var orderedMenuItems = await _dbContext.Set<Order>()
            .Where(o => o.ReservationId == ReservationId)
            .SelectMany(o => o.OrderItems.Select(it => it.MenuItem))
            .ToListAsync();

        return orderedMenuItems;
    }
}