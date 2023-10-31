using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
public class CustomerRepository : IEntityRepository<Customer>
{
    private readonly EntityRepositoryBase<Customer> _entityRepository;

    public CustomerRepository(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        _entityRepository = new EntityRepositoryBase<Customer>(dbContext);
    }

    public async Task<List<Customer>> RetrieveAllAsync()
    {
        return await _entityRepository.RetrieveAllAsync();
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        return await _entityRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(Customer entity)
    {
        await _entityRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(Customer entity)
    {
        await _entityRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _entityRepository.DeleteAsync(id);
    }
}