using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
public class TableRepository : EntityRepositoryBase<Table>
{
    public TableRepository(DbContext dbContext) : base(dbContext)
    {
    }
}