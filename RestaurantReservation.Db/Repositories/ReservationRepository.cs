using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
public class ReservationRepository : EntityRepositoryBase<Reservation>
{
    public ReservationRepository(DbContext dbContext) : base(dbContext)
    {
    }
}