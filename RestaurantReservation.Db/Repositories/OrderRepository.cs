using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.IRepositories;
using RestaurantReservation.Repositories;
public class OrderRepository : EntityRepositoryBase<Order, int>, IOrderRepository
{
    public OrderRepository(DbContextOptions<RestaurantReservationDbContext> dbContextOptions)
        : base(new RestaurantReservationDbContext(dbContextOptions))
    {
    }

    public async Task<List<Order>> ListOrdersAndMenuItems(int ReservationId)
    {
        return await _dbContext.Set<Order>()
                       .Where(o => o.ReservationId == ReservationId)
                       .ToListAsync();
    }
}