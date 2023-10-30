namespace RestaurantReservation.Repositories
{
    public interface IEntityRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> RetrieveAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}