using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
namespace RestaurantReservation.Db
{
    public class RestaurantReservationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data Source=DESKTOP-CUQN3UP\\SQLEXPRESS;Initial Catalog=RestaurantReservationCore;Integrated Security=True;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Reservation> Reservations { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<Restaurant> Restaurants { set; get; }
        public DbSet<MenuItem> MenuItems { set; get; }
        public DbSet<OrderItem> OrderItems { set; get; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Customer> Customers { set; get; }
        public DbSet<Employee> Employees { set; get; }
    }
}