using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.IRepositories;
using RestaurantReservation.Repositories;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;

public class TableRepository : EntityRepositoryBase<Table, int>, ITableRepository
{
    public TableRepository(DbContextOptions<RestaurantReservationDbContext> dbContextOptions)
        : base(new RestaurantReservationDbContext(dbContextOptions))
    {
    }
}