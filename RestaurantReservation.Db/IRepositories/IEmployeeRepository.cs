using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Viewes;
using System.Security.Cryptography;

namespace RestaurantReservation.Db.IRepositories
{
    public interface IEmployeeRepository<TId> : IEntityRepository<Employee, TId>
    {
        Task<List<Employee>> ListManagersAsync();
        Task<double?> CalculateAverageOrderAmountAsync(TId EmployeeId);
        Task<List<EmployeeRestaurantDetailsView>> GetEmployeesWithRestaurantDetailsAsync();
    }
}