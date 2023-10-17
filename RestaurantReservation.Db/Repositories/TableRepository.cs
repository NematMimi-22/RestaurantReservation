using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
public class TableRepository : IEntityRepository<Table>
{
    private readonly RestaurantReservationDbContext _dbContext;

    public TableRepository(RestaurantReservationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<List<Table>> GetAllAsync()
    {
        return await _dbContext.Tables.ToListAsync();
    }

    public async Task<Table> GetByIdAsync(int TableId)
    {
        return await _dbContext.Tables.FindAsync(TableId);
    }

    public async Task CreateAsync(Table Table)
    {
        _dbContext.Tables.Add(Table);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Table Table)
    {
        _dbContext.Entry(Table).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int TableId)
    {
        var Table = await _dbContext.Tables.FindAsync(TableId);
        if (Table != null)
        {
            _dbContext.Tables.Remove(Table);
            await _dbContext.SaveChangesAsync();
        }
    }
}