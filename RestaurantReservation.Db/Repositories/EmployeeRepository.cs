using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.IRepositories;
using RestaurantReservation.Db.Viewes;
namespace RestaurantReservation.Repositories
{
    public class EmployeeRepository : EntityRepositoryBase<Employee, int>, IEmployeeRepository
    {
        public EmployeeRepository(DbContextOptions<RestaurantReservationDbContext> dbContextOptions)
        : base(new RestaurantReservationDbContext(dbContextOptions))
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

        public async Task<IEnumerable<Employee>> GetManagersAsync()
        {
            return await _dbContext.Set<Employee>()
                .Where(e => e.Position == "Manager")
                .ToListAsync();
        }

        public async Task<double> GetAverageOrderAmountAsync(int employeeId)
        {
            var averageOrderAmount = await _dbContext.Set<Order>()
                .Where(o => o.EmployeeId == employeeId)
                .AverageAsync(o => o.TotalAmount);

            return averageOrderAmount;
        }
    }
}