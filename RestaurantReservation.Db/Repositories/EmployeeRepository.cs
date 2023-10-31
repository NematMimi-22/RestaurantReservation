using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Viewes;
namespace RestaurantReservation.Repositories
{
    public class EmployeeRepository<TEntity> : IEntityRepository<Employee>
    {
        private readonly EntityRepositoryBase<Employee> _entityRepository;
        private readonly Microsoft.EntityFrameworkCore.DbContext _dbContext;

        public EmployeeRepository(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _entityRepository = new EntityRepositoryBase<Employee>(dbContext);
        }

        public async Task<List<Employee>> RetrieveAllAsync()
        {
            return await _entityRepository.RetrieveAllAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _entityRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Employee entity)
        {
            await _entityRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(Employee entity)
        {
            await _entityRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _entityRepository.DeleteAsync(id);
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