using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Repositories;
public class MenuItemRepository : EntityRepositoryBase<MenuItem>
{
    public MenuItemRepository(DbContext dbContext) : base(dbContext)
    {
    }
}