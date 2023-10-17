using System;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Seed_Data
{
    public static class SeedData
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, FirstName = "Nemat", LastName = "Mimi", Email = "nematmimi01@gmail.com", PhoneNumber = "0597104204" },
                new Customer { CustomerId = 2, FirstName = "Malak", LastName = "Ayman", Email = "malak06@gmaiol.com", PhoneNumber = "0597104000" },
                new Customer { CustomerId = 3, FirstName = "Manar", LastName = "Meme", Email = "manar22@gmail.com", PhoneNumber = "0598884204" },
                new Customer { CustomerId = 4, FirstName = "Ali", LastName = "Abuhijleh", Email = "ali123@gmail.com", PhoneNumber = "0597104567" },
                new Customer { CustomerId = 5, FirstName = "Sara", LastName = "Ahmad", Email = "sara33@gmail.com", PhoneNumber = "0596554204" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, RestaurantId = 1, FirstName = "John", LastName = "Doe", Position = "Chef" },
                new Employee { EmployeeId = 2, RestaurantId = 1, FirstName = "Jane", LastName = "Smith", Position = "Waiter" },
                new Employee { EmployeeId = 3, RestaurantId = 1, FirstName = "Michael", LastName = "Johnson", Position = "Bartender" },
                new Employee { EmployeeId = 4, RestaurantId = 1, FirstName = "Emily", LastName = "Davis", Position = "Server" },
                new Employee { EmployeeId = 5, RestaurantId = 1, FirstName = "David", LastName = "Miller", Position = "Manager" }
            );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { MenuItemId = 1, RestaurantId = 1, Name = "Spaghetti Bolognese", Description = "Classic Italian pasta with meat sauce", Price = 12.9 },
                new MenuItem { MenuItemId = 2, RestaurantId = 1, Name = "Margherita Pizza", Description = "Traditional pizza with tomato sauce and mozzarella cheese", Price = 10.99 },
                new MenuItem { MenuItemId = 3, RestaurantId = 1, Name = "Grilled Salmon", Description = "Fresh grilled salmon served with vegetables", Price = 18.99 },
                new MenuItem { MenuItemId = 4, RestaurantId = 1, Name = "Caesar Salad", Description = "Crisp romaine lettuce, croutons, and parmesan cheese, dressed with Caesar dressing", Price = 8.99 },
                new MenuItem { MenuItemId = 5, RestaurantId = 1, Name = "Cheesecake", Description = "Creamy New York-style cheesecake with strawberry topping", Price = 6.99 }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, ReservationId = 1, EmployeeId = 1, OrderDate = DateTime.Now, TotalAmount = 35.97 },
                new Order { OrderId = 2, ReservationId = 2, EmployeeId = 2, OrderDate = DateTime.Now, TotalAmount = 29.97 },
                new Order { OrderId = 3, ReservationId = 3, EmployeeId = 3, OrderDate = DateTime.Now, TotalAmount = 41.97 },
                new Order { OrderId = 4, ReservationId = 4, EmployeeId = 4, OrderDate = DateTime.Now, TotalAmount = 27.97 },
                new Order { OrderId = 5, ReservationId = 5, EmployeeId = 5, OrderDate = DateTime.Now, TotalAmount = 18.97 }
            );

            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { OrderItemId = 1, OrderId = 1, MenuitemId = 1, ItemId = 1, Quantity = 3 },
                new OrderItem { OrderItemId = 2, OrderId = 2, MenuitemId = 2, ItemId = 2, Quantity = 2 },
                new OrderItem { OrderItemId = 3, OrderId = 3, MenuitemId = 3, ItemId = 3, Quantity = 4 },
                new OrderItem { OrderItemId = 4, OrderId = 4, MenuitemId = 4, ItemId = 4, Quantity = 1 },
                new OrderItem { OrderItemId = 5, OrderId = 5, MenuitemId = 5, ItemId = 5, Quantity = 2 }
            );

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { ReservationId = 1, CustomerId = 1, RestaurantId = 1, TableId = 1, ReservationDate = DateTime.Now, PartySize = 3 },
                new Reservation { ReservationId = 2, CustomerId = 2, RestaurantId = 1, TableId = 2, ReservationDate = DateTime.Now, PartySize = 2 },
                new Reservation { ReservationId = 3, CustomerId = 3, RestaurantId = 1, TableId = 3, ReservationDate = DateTime.Now, PartySize = 4 },
                new Reservation { ReservationId = 4, CustomerId = 4, RestaurantId = 1, TableId = 4, ReservationDate = DateTime.Now, PartySize = 1 },
                new Reservation { ReservationId = 5, CustomerId = 5, RestaurantId = 1, TableId = 5, ReservationDate = DateTime.Now, PartySize = 2 }
            );

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant { RestaurantId = 1, Name = "Hiven", Address = "456 Oak Street", PhoneNumber = "555-123-4567", OpeningHours = "10 AM - 11 PM" }
            );

            modelBuilder.Entity<Table>().HasData(
                new Table { TableId = 1, RestaurantId = 1, Capacity = 4 },
                new Table { TableId = 2, RestaurantId = 1, Capacity = 2 },
                new Table { TableId = 3, RestaurantId = 1, Capacity = 6 },
                new Table { TableId = 4, RestaurantId = 1, Capacity = 2 },
                new Table { TableId = 5, RestaurantId = 1, Capacity = 4 }
            );
        }
    }
}