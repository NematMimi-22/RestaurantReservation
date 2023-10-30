using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
public class CustomerRepository : EntityRepositoryBase<Customer>, IEntityRepository<Customer>
{
    public CustomerRepository(DbContext dbContext) : base(dbContext)
    {
    }
}