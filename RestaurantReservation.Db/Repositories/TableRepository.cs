using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.IRepositories;
using RestaurantReservation.Repositories;
using Microsoft.EntityFrameworkCore;
public class TableRepository : EntityRepositoryBase<Table, int>, ITableRepository<int>
{
    public TableRepository(DbContext dbContext) : base(dbContext)
    {
    }
}