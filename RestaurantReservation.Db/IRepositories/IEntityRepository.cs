namespace RestaurantReservation.Db.IRepositories
{
    public interface IEntityRepository<TEntity, TId> where TEntity : class
    {
        Task<List<TEntity>> RetrieveAllAsync();
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TId id);
        Task<TEntity> GetByIdAsync(TId id);
    }
}