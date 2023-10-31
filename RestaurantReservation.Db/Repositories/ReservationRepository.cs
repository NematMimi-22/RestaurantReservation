using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Viewes;
using RestaurantReservation.Repositories;
using Umbraco.Core.Persistence.Repositories;

public class ReservationRepository : IEntityRepository<Reservation>
{
    private readonly EntityRepositoryBase<Reservation> _entityRepository;
    private readonly Microsoft.EntityFrameworkCore.DbContext _dbContext;

    public ReservationRepository(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _entityRepository = new EntityRepositoryBase<Reservation>(dbContext);
    }

    public async Task<List<Reservation>> RetrieveAllAsync()
    {
        return await _entityRepository.RetrieveAllAsync();
    }

    public async Task<Reservation> GetByIdAsync(int id)
    {
        return await _entityRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(Reservation entity)
    {
        await _entityRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(Reservation entity)
    {
        await _entityRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _entityRepository.DeleteAsync(id);
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