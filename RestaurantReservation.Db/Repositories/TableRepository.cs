using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
public class TableRepository : IEntityRepository<Table>
{
    private readonly EntityRepositoryBase<Table> _entityRepository;

    public TableRepository(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        _entityRepository = new EntityRepositoryBase<Table>(dbContext);
    }

    public async Task<List<Table>> RetrieveAllAsync()
    {
        return await _entityRepository.RetrieveAllAsync();
    }

    public async Task<Table> GetByIdAsync(int id)
    {
        return await _entityRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(Table entity)
    {
        await _entityRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(Table entity)
    {
        await _entityRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _entityRepository.DeleteAsync(id);
    }
}