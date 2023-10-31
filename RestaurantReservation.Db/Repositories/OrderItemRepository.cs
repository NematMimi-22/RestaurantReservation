using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.IRepositories;
using RestaurantReservation.Repositories;
using Microsoft.EntityFrameworkCore;
public class OrderItemRepository : EntityRepositoryBase<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(DbContext dbContext) : base(dbContext)
    {
    }
}