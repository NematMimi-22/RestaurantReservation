using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.IRepositories;
using RestaurantReservation.Repositories;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;

public class RestaurantRepository : EntityRepositoryBase<Restaurant, int>, IRestaurantRepository
{
    public RestaurantRepository(DbContextOptions<RestaurantReservationDbContext> dbContextOptions)
        : base(new RestaurantReservationDbContext(dbContextOptions))
    {
    }
}