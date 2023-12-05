using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Viewes;
using System.Security.Cryptography;

namespace RestaurantReservation.Db.IRepositories
{
    public interface IEmployeeRepository : IEntityRepository<Employee, int>
    {
        Task<List<Employee>> ListManagersAsync();
        Task<double?> CalculateAverageOrderAmountAsync(int EmployeeId);
        Task<List<EmployeeRestaurantDetailsView>> GetEmployeesWithRestaurantDetailsAsync();
        Task<IEnumerable<Employee>> GetManagersAsync();
        Task<double> GetAverageOrderAmountAsync(int employeeId);
    }
}