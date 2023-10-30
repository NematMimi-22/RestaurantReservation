using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
public class TableRepository : EntityRepositoryBase<Table>, IEntityRepository<Table>
{
    public TableRepository(DbContext dbContext) : base(dbContext)
    {
    }
}