using Microsoft.EntityFrameworkCore;

public class RestaurantReservationDbContext : DbContext
{

    public RestaurantReservationDbContext(DbContextOptions<RestaurantReservationDbContext> options) : base(options)
    {
    }
}
