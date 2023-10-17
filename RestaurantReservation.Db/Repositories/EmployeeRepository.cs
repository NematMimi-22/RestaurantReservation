using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
public class EmployeeRepository : IEntityRepository<Employee>
{
    private readonly RestaurantReservationDbContext _dbContext;

    public EmployeeRepository(RestaurantReservationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        return await _dbContext.Employees.ToListAsync();
    }

    public async Task<Employee> GetByIdAsync(int EmployeeId)
    {
        return await _dbContext.Employees.FindAsync(EmployeeId);
    }

    public async Task CreateAsync(Employee employee)
    {
        _dbContext.Employees.Add(employee);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Employee employee)
    {
        _dbContext.Entry(employee).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int EmployeeId)
    {
        var employee = await _dbContext.Employees.FindAsync(EmployeeId);
        if (employee != null)
        {
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<List<Employee>> ListManagersAsync()
    {
        return await _dbContext.Employees
            .Where(e => e.Position == "Manager")
            .ToListAsync();
    }

    public async Task<double?> CalculateAverageOrderAmountAsync(int EmployeeId)
    {
        var orders = await _dbContext.Orders
            .Where(o => o.EmployeeId == EmployeeId)
            .ToListAsync();
        if (!orders.IsNullOrEmpty())
        {
            var averageAmount = (orders.Sum(o => o.TotalAmount))/orders.Count;

            return averageAmount;
        }
        else
        {
            return 0;
        }
    }
}