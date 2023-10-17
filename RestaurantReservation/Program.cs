using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db;
namespace RestaurantReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<RestaurantReservationDbContext>(options =>
                options.UseSqlServer("Data Source=DESKTOP-CUQN3UP\\SQLEXPRESS;Initial Catalog=RestaurantReservationCore;Integrated Security=True;TrustServerCertificate=true"))
                .BuildServiceProvider();

            using (var context = serviceProvider.GetRequiredService<RestaurantReservationDbContext>())
            {
                context.Database.EnsureCreated();
                var customers = context.Customers.ToList();
                var employees = context.Employees.ToList();
                var menuItems = context.MenuItems.ToList();
                var orders = context.Orders.Include(o => o.OrderItems).ToList();
                var reservations = context.Reservations.Include(r => r.Orders).ToList();

                Console.WriteLine("Customers:");
                foreach (var customer in customers)
                {
                    Console.WriteLine($"Customer ID: {customer.CustomerId}, Name: {customer.FirstName} {customer.LastName}");
                }

                Console.WriteLine("\nEmployees:");
                foreach (var employee in employees)
                {
                    Console.WriteLine($"Employee ID: {employee.EmployeeId}, Name: {employee.FirstName} {employee.LastName}, Position: {employee.Position}");
                }

                Console.WriteLine("\nMenu Items:");
                foreach (var menuItem in menuItems)
                {
                    Console.WriteLine($"Menu Item ID: {menuItem.MenuItemId}, Name: {menuItem.Name}, Price: {menuItem.Price}");
                }

                Console.WriteLine("\nOrders:");
                foreach (var order in orders)
                {
                    Console.WriteLine($"Order ID: {order.OrderId}, Total Amount: {order.TotalAmount}");
                    foreach (var orderItem in order.OrderItems)
                    {
                        Console.WriteLine($"  Order Item ID: {orderItem.OrderItemId}, Quantity: {orderItem.Quantity}");
                    }
                }

                Console.WriteLine("\nReservations:");
                foreach (var reservation in reservations)
                {
                    Console.WriteLine($"Reservation ID: {reservation.ReservationId}, Party Size: {reservation.PartySize}");
                    foreach (var order in reservation.Orders)
                    {
                        Console.WriteLine($"  Order ID: {order.OrderId}, Total Amount: {order.TotalAmount}");
                    }
                }
            }
        }
    }
}