using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
public class EmployeeRepository : EntityRepositoryBase<Employee>
{
    public EmployeeRepository(DbContext dbContext) : base(dbContext)
    {
    }
}