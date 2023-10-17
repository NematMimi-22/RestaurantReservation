using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Viewes;
using RestaurantReservation.Repositories;
public class ReservationRepository : IEntityRepository<Reservation>
{
    private readonly RestaurantReservationDbContext _dbContext;

    public ReservationRepository(RestaurantReservationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<List<Reservation>> GetAllAsync()
    {
        return await _dbContext.Reservations.ToListAsync();
    }

    public async Task<Reservation> GetByIdAsync(int ReservationId)
    {
        return await _dbContext.Reservations.FindAsync(ReservationId);
    }

    public async Task CreateAsync(Reservation Reservation)
    {
        _dbContext.Reservations.Add(Reservation);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Reservation Reservation)
    {
        _dbContext.Entry(Reservation).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int ReservationId)
    {
        var Reservation = await _dbContext.Reservations.FindAsync(ReservationId);
        if (Reservation != null)
        {
            _dbContext.Reservations.Remove(Reservation);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<List<Reservation>> GetReservationsByCustomer(int CustomerId)
    {
        return await _dbContext.Reservations
            .Where(r => r.CustomerId == CustomerId)
            .ToListAsync();
    }

    public async Task<List<ReservationDetailsView>> GetReservationsWithDetailsAsync()
    {
        return await _dbContext.ReservationDetailsView.ToListAsync();
    }
}