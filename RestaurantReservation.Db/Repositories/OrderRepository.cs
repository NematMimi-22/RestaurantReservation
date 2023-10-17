using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
public class OrderRepository : IEntityRepository<Order>
{
    private readonly RestaurantReservationDbContext _dbContext;

    public OrderRepository(RestaurantReservationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _dbContext.Orders.ToListAsync();
    }

    public async Task<Order> GetByIdAsync(int OrderId)
    {
        return await _dbContext.Orders.FindAsync(OrderId);
    }

    public async Task CreateAsync(Order Order)
    {
        _dbContext.Orders.Add(Order);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order Order)
    {
        _dbContext.Entry(Order).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int OrderId)
    {
        var Order = await _dbContext.Orders.FindAsync(OrderId);
        if (Order != null)
        {
            _dbContext.Orders.Remove(Order);
            await _dbContext.SaveChangesAsync();
        }
    }
}