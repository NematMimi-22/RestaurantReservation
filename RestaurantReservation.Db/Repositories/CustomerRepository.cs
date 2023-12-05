using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.IRepositories;
using RestaurantReservation.Db;
using RestaurantReservation.Repositories;

public class CustomerRepository : EntityRepositoryBase<Customer, int>, ICustomerRepository
{
    public CustomerRepository(DbContextOptions<RestaurantReservationDbContext> dbContextOptions)
        : base(new RestaurantReservationDbContext(dbContextOptions))
    {
    }
}