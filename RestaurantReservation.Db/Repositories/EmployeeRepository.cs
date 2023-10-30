using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Viewes;
using RestaurantReservation.Repositories;
namespace RestaurantReservation.Repositories
{
    public class EmployeeRepository : EntityRepositoryBase<Employee>
    {
        public EmployeeRepository(DbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Employee>> ListManagersAsync()
        {
            return await _dbContext.Set<Employee>()
                .Where(e => e.Position == "Manager")
                .ToListAsync();
        }
        public async Task<double?> CalculateAverageOrderAmountAsync(int EmployeeId)
        {
            var orders = await _dbContext.Set<Order>()
                .Where(o => o.EmployeeId == EmployeeId)
                .ToListAsync();
            if (!orders.IsNullOrEmpty())
            {
                var averageAmount = (orders.Sum(o => o.TotalAmount)) / orders.Count;

                return averageAmount;
            }
            else
            {
                return 0;
            }
        }

        public async Task<List<EmployeeRestaurantDetailsView>> GetEmployeesWithRestaurantDetailsAsync()
        {
            return await _dbContext.Set<EmployeeRestaurantDetailsView>().ToListAsync();
        }
    }
}