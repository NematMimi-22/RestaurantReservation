using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
public class RestaurantRepository : IEntityRepository<Restaurant>
{
    private readonly EntityRepositoryBase<Restaurant> _entityRepository;

    public RestaurantRepository(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        _entityRepository = new EntityRepositoryBase<Restaurant>(dbContext);
    }

    public async Task<List<Restaurant>> RetrieveAllAsync()
    {
        return await _entityRepository.RetrieveAllAsync();
    }

    public async Task<Restaurant> GetByIdAsync(int id)
    {
        return await _entityRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(Restaurant entity)
    {
        await _entityRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(Restaurant entity)
    {
        await _entityRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _entityRepository.DeleteAsync(id);
    }
}