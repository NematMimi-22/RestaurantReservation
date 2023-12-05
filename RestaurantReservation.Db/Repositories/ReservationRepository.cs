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

    public async Task<IEnumerable<Reservation>> GetReservationsByCustomerAsync(int customerId)
    {
        return await _dbContext.Set<Reservation>()
            .Where(r => r.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersForReservationAsync(int reservationId)
    {
        return await _dbContext.Set<Order>()
            .Where(o => o.ReservationId == reservationId)
            .ToListAsync();
    }

    public async Task<IEnumerable<MenuItem>> GetMenuItemsForReservationAsync(int reservationId)
    {
        return await _dbContext.Set<OrderItem>()
            .Where(oi => oi.Order.ReservationId == reservationId)
            .Select(oi => oi.MenuItem)
            .ToListAsync();
    }
}