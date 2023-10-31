using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.IRepositories;
using RestaurantReservation.Repositories;
public class OrderRepository : EntityRepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Order>> ListOrdersAndMenuItems(int ReservationId)
    {
        return await _dbContext.Set<Order>()
                       .Where(o => o.ReservationId == ReservationId)
                       .ToListAsync();
    }
}