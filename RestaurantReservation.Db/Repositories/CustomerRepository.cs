using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.IRepositories;
using RestaurantReservation.Repositories;
using Microsoft.EntityFrameworkCore;
public class CustomerRepository : EntityRepositoryBase<Customer>, ICustomerRepository
{
    public CustomerRepository(DbContext dbContext) : base(dbContext) 
    {
    }
}