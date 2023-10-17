using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
public class CustomerRepository : IEntityRepository<Customer>
{
    private readonly RestaurantReservationDbContext _dbContext;

    public CustomerRepository(RestaurantReservationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await _dbContext.Customers.ToListAsync();
    }

    public async Task<Customer> GetByIdAsync(int CustomerId)
    {
        return await _dbContext.Customers.FindAsync(CustomerId);
    }

    public async Task CreateAsync(Customer Customer)
    {
        _dbContext.Customers.Add(Customer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer Customer)
    {
        _dbContext.Entry(Customer).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int CustomerId)
    {
        var Customer = await _dbContext.Customers.FindAsync(CustomerId);
        if (Customer != null)
        {
            _dbContext.Customers.Remove(Customer);
            await _dbContext.SaveChangesAsync();
        }
    }
}