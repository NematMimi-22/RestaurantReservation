using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
public class OrderItemRepository : IEntityRepository<OrderItem>
{
    private readonly EntityRepositoryBase<OrderItem> _entityRepository;

    public OrderItemRepository(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        _entityRepository = new EntityRepositoryBase<OrderItem>(dbContext);
    }

    public async Task<List<OrderItem>> RetrieveAllAsync()
    {
        return await _entityRepository.RetrieveAllAsync();
    }

    public async Task<OrderItem> GetByIdAsync(int id)
    {
        return await _entityRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(OrderItem entity)
    {
        await _entityRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(OrderItem entity)
    {
        await _entityRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _entityRepository.DeleteAsync(id);
    }
}