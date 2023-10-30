using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
public class RestaurantRepository : EntityRepositoryBase<Restaurant>
{
    public RestaurantRepository(DbContext dbContext) : base(dbContext)
    {
    }
}