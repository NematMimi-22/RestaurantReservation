using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.IRepositories;
using RestaurantReservation.Repositories;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;

public class OrderItemRepository : EntityRepositoryBase<OrderItem, int>, IOrderItemRepository
{
    public OrderItemRepository(DbContextOptions<RestaurantReservationDbContext> dbContextOptions)
        : base(new RestaurantReservationDbContext(dbContextOptions))
    {
    }
}