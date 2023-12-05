using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.IRepositories;
using RestaurantReservation.Db.Viewes;
using RestaurantReservation.Repositories;
public class ReservationRepository : EntityRepositoryBase<Reservation, int>, IReservationRepository
{
    public ReservationRepository(DbContextOptions<RestaurantReservationDbContext> dbContextOptions)
        : base(new RestaurantReservationDbContext(dbContextOptions))
    {
    }

    public async Task<List<Reservation>> GetReservationsByReservation(int ReservationId)
    {
        return await _dbContext.Set<Reservation>()
            .Where(r => r.ReservationId == ReservationId)
            .ToListAsync();
    }

    public async Task<List<ReservationDetailsView>> GetReservationsWithDetailsAsync()
    {
        return await _dbContext.Set<ReservationDetailsView>().ToListAsync();
    }
}