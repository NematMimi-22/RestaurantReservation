using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Viewes;
using RestaurantReservation.Repositories;
public class ReservationRepository : EntityRepositoryBase<Reservation>
{
    public ReservationRepository(DbContext dbContext) : base(dbContext)
    {
    }
    public async Task<List<Reservation>> GetReservationsByCustomer(int CustomerId)
    {
        return await _dbContext.Set<Reservation>()
            .Where(r => r.CustomerId == CustomerId)
            .ToListAsync();
    }

    public async Task<List<ReservationDetailsView>> GetReservationsWithDetailsAsync()
    {
        return await _dbContext.Set<ReservationDetailsView>().ToListAsync();
    }
}