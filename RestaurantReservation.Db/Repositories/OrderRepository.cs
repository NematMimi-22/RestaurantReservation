using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
public class OrderRepository : EntityRepositoryBase<Order>
{
    public OrderRepository(DbContext dbContext) : base(dbContext)
    {
    }
}