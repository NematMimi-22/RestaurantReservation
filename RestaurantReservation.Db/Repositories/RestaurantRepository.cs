using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
public class RestaurantRepository : IEntityRepository<Restaurant>
{
    private readonly RestaurantReservationDbContext _dbContext;

    public RestaurantRepository(RestaurantReservationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<List<Restaurant>> GetAllAsync()
    {
        return await _dbContext.Restaurants.ToListAsync();
    }

    public async Task<Restaurant> GetByIdAsync(int RestaurantId)
    {
        return await _dbContext.Restaurants.FindAsync(RestaurantId);
    }

    public async Task CreateAsync(Restaurant Restaurant)
    {
        _dbContext.Restaurants.Add(Restaurant);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Restaurant Restaurant)
    {
        _dbContext.Entry(Restaurant).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int RestaurantId)
    {
        var Restaurant = await _dbContext.Restaurants.FindAsync(RestaurantId);
        if (Restaurant != null)
        {
            _dbContext.Restaurants.Remove(Restaurant);
            await _dbContext.SaveChangesAsync();
        }
    }
}