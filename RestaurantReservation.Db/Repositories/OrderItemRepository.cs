using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
public class OrderItemRepository : EntityRepositoryBase<OrderItem>
{
    public OrderItemRepository(DbContext dbContext) : base(dbContext)
    {
    }
}