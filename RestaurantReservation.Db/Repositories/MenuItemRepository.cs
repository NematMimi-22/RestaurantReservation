using Microsoft.EntityFrameworkCore;
using NPoco;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
public class MenuItemRepository : IEntityRepository<MenuItem>
{
    private readonly RestaurantReservationDbContext _dbContext;

    public MenuItemRepository(RestaurantReservationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<List<MenuItem>> GetAllAsync()
    {
        return await _dbContext.MenuItems.ToListAsync();
    }

    public async Task<MenuItem> GetByIdAsync(int MenuItemId)
    {
        return await _dbContext.MenuItems.FindAsync(MenuItemId);
    }

    public async Task CreateAsync(MenuItem MenuItem)
    {
        _dbContext.MenuItems.Add(MenuItem);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(MenuItem MenuItem)
    {
        _dbContext.Entry(MenuItem).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int MenuItemId)
    {
        var MenuItem = await _dbContext.MenuItems.FindAsync(MenuItemId);
        if (MenuItem != null)
        {
            _dbContext.MenuItems.Remove(MenuItem);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<List<MenuItem>> ListOrderedMenuItems(int ReservationId)
    {
        return await _dbContext.Orders
                       .Where(o => o.ReservationId == ReservationId)
                       .SelectMany(o => o.OrderItems.Select(it => it.MenuItem))
                       .ToListAsync();
    }
}