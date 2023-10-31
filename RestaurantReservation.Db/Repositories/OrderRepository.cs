using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
public class OrderRepository :  IEntityRepository<Order>
{
    private readonly EntityRepositoryBase<Order> _entityRepository;
    private readonly Microsoft.EntityFrameworkCore.DbContext _dbContext;

    public OrderRepository(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _entityRepository = new EntityRepositoryBase<Order>(dbContext);
    }

    public async Task<List<Order>> RetrieveAllAsync()
    {
        return await _entityRepository.RetrieveAllAsync();
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        return await _entityRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(Order entity)
    {
        await _entityRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(Order entity)
    {
        await _entityRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _entityRepository.DeleteAsync(id);
    }

    public async Task<List<Order>> ListOrdersAndMenuItems(int ReservationId)
    {
        return await _dbContext.Set<Order>()
                       .Where(o => o.ReservationId == ReservationId)
                       .ToListAsync();
    }
}