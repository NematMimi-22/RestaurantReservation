using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class MenuItemRepository : EntityRepositoryBase<MenuItem>, IEntityRepository<MenuItem>
{
    public MenuItemRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<MenuItem>> ListOrderedMenuItems(int ReservationId)
    {
        return await _dbContext.Set<Order>()
            .Where(o => o.ReservationId == ReservationId)
            .SelectMany(o => o.OrderItems.Select(it => it.MenuItem))
            .ToListAsync();
    }
}