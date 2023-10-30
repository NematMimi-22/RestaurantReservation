using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
public class RestaurantRepository : EntityRepositoryBase<Restaurant>, IEntityRepository<Restaurant>
{
    public RestaurantRepository(DbContext dbContext) : base(dbContext)
    {
    }
}