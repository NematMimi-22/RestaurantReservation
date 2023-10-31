using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Viewes;
namespace RestaurantReservation.Db.IRepositories
{
    public interface IEmployeeRepository : IEntityRepository<Employee>
    {
        Task<List<Employee>> ListManagersAsync();
        Task<double?> CalculateAverageOrderAmountAsync(int EmployeeId);
        Task<List<EmployeeRestaurantDetailsView>> GetEmployeesWithRestaurantDetailsAsync();
    }
}