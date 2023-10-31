using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db;
using RestaurantReservation.Repositories;
using Umbraco.Core.Models.Entities;

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

                Console.WriteLine("Customers:");
                context.Customers.ToList().ForEach(customer =>
                {
                    Console.WriteLine($"Customer ID: {customer.CustomerId}, Name: {customer.FirstName} {customer.LastName}");
                });

                Console.WriteLine("\nEmployees:");
                context.Employees.ToList().ForEach(employee =>
                {
                    Console.WriteLine($"Employee ID: {employee.EmployeeId}, Name: {employee.FirstName} {employee.LastName}, Position: {employee.Position}");
                });

                Console.WriteLine("\nMenu Items:");
                context.MenuItems.ToList().ForEach(menuItem =>
                {
                    Console.WriteLine($"Menu Item ID: {menuItem.MenuItemId}, Name: {menuItem.Name}, Price: {menuItem.Price}");
                });

                Console.WriteLine("\nOrders:");
                context.Orders.Include(o => o.OrderItems).ToList().ForEach(order =>
                {
                    Console.WriteLine($"Order ID: {order.OrderId}, Total Amount: {order.TotalAmount}");
                    order.OrderItems.ForEach(orderItem =>
                    {
                        Console.WriteLine($"  Order Item ID: {orderItem.OrderItemId}, Quantity: {orderItem.Quantity}");
                    });
                });

                Console.WriteLine("\nReservations:");
                context.Reservations.Include(r => r.Orders).ToList().ForEach(reservation =>
                {
                    Console.WriteLine($"Reservation ID: {reservation.ReservationId}, Party Size: {reservation.PartySize}");
                    reservation.Orders.ForEach(order =>
                    {
                        Console.WriteLine($"  Order ID: {order.OrderId}, Total Amount: {order.TotalAmount}");
                    });
                });
            }
        }
    }
}