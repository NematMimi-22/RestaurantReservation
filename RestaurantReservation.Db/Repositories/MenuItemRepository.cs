using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
using System.Data.Entity;
public class MenuItemRepository : IEntityRepository<MenuItem>
{
    private readonly EntityRepositoryBase<MenuItem> _entityRepository;
    private readonly Microsoft.EntityFrameworkCore.DbContext _dbContext; 

    public MenuItemRepository(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _entityRepository = new EntityRepositoryBase<MenuItem>(dbContext);
    }

    public async Task<List<MenuItem>> RetrieveAllAsync()
    {
        return await _entityRepository.RetrieveAllAsync();
    }

    public async Task<MenuItem> GetByIdAsync(int id)
    {
        return await _entityRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(MenuItem entity)
    {
        await _entityRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(MenuItem entity)
    {
        await _entityRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _entityRepository.DeleteAsync(id);
    }

    public async Task<List<MenuItem>> ListOrderedMenuItems(int ReservationId)
    {
        var orderedMenuItems = await _dbContext.Set<Order>()
            .Where(o => o.ReservationId == ReservationId)
            .SelectMany(o => o.OrderItems.Select(it => it.MenuItem))
            .ToListAsync();

        return orderedMenuItems;
    }
}
