using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
public class OrderItemRepository : IEntityRepository<OrderItem>
{
    private readonly RestaurantReservationDbContext _dbContext;

    public OrderItemRepository(RestaurantReservationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<List<OrderItem>> GetAllAsync()
    {
        return await _dbContext.OrderItems.ToListAsync();
    }

    public async Task<OrderItem> GetByIdAsync(int OrderItemId)
    {
        return await _dbContext.OrderItems.FindAsync(OrderItemId);
    }

    public async Task CreateAsync(OrderItem OrderItem)
    {
        _dbContext.OrderItems.Add(OrderItem);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(OrderItem OrderItem)
    {
        _dbContext.Entry(OrderItem).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int OrderItemId)
    {
        var OrderItem = await _dbContext.OrderItems.FindAsync(OrderItemId);
        if (OrderItem != null)
        {
            _dbContext.OrderItems.Remove(OrderItem);
            await _dbContext.SaveChangesAsync();
        }
    }
}