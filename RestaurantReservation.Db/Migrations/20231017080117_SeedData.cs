using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TotalAmount",
                table: "Orders",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "MenuItems",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "nematmimi01@gmail.com", "Nemat", "Mimi", "0597104204" },
                    { 2, "malak06@gmaiol.com", "Malak", "Ayman", "0597104000" },
                    { 3, "manar22@gmail.com", "Manar", "Meme", "0598884204" },
                    { 4, "ali123@gmail.com", "Ali", "Abuhijleh", "0597104567" },
                    { 5, "sara33@gmail.com", "Sara", "Ahmad", "0596554204" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "Address", "Name", "OpeningHours", "PhoneNumber" },
                values: new object[] { 1, "456 Oak Street", "Hiven", "10 AM - 11 PM", "555-123-4567" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "Position", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "John", "Doe", "Chef", 1 },
                    { 2, "Jane", "Smith", "Waiter", 1 },
                    { 3, "Michael", "Johnson", "Bartender", 1 },
                    { 4, "Emily", "Davis", "Server", 1 },
                    { 5, "David", "Miller", "Manager", 1 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "Description", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Classic Italian pasta with meat sauce", "Spaghetti Bolognese", 12.9, 1 },
                    { 2, "Traditional pizza with tomato sauce and mozzarella cheese", "Margherita Pizza", 10.99, 1 },
                    { 3, "Fresh grilled salmon served with vegetables", "Grilled Salmon", 18.989999999999998, 1 },
                    { 4, "Crisp romaine lettuce, croutons, and parmesan cheese, dressed with Caesar dressing", "Caesar Salad", 8.9900000000000002, 1 },
                    { 5, "Creamy New York-style cheesecake with strawberry topping", "Cheesecake", 6.9900000000000002, 1 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Capacity", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 2, 1 },
                    { 3, 6, 1 },
                    { 4, 2, 1 },
                    { 5, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CustomerId", "PartySize", "ReservationDate", "RestaurantId", "TableId" },
                values: new object[,]
                {
                    { 1, 1, 3, new DateTime(2023, 10, 17, 11, 1, 17, 289, DateTimeKind.Local).AddTicks(5694), 1, 1 },
                    { 2, 2, 2, new DateTime(2023, 10, 17, 11, 1, 17, 289, DateTimeKind.Local).AddTicks(5697), 1, 2 },
                    { 3, 3, 4, new DateTime(2023, 10, 17, 11, 1, 17, 289, DateTimeKind.Local).AddTicks(5699), 1, 3 },
                    { 4, 4, 1, new DateTime(2023, 10, 17, 11, 1, 17, 289, DateTimeKind.Local).AddTicks(5701), 1, 4 },
                    { 5, 5, 2, new DateTime(2023, 10, 17, 11, 1, 17, 289, DateTimeKind.Local).AddTicks(5702), 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "EmployeeId", "OrderDate", "ReservationId", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 17, 11, 1, 17, 289, DateTimeKind.Local).AddTicks(5625), 1, 35.969999999999999 },
                    { 2, 2, new DateTime(2023, 10, 17, 11, 1, 17, 289, DateTimeKind.Local).AddTicks(5658), 2, 29.969999999999999 },
                    { 3, 3, new DateTime(2023, 10, 17, 11, 1, 17, 289, DateTimeKind.Local).AddTicks(5660), 3, 41.969999999999999 },
                    { 4, 4, new DateTime(2023, 10, 17, 11, 1, 17, 289, DateTimeKind.Local).AddTicks(5662), 4, 27.969999999999999 },
                    { 5, 5, new DateTime(2023, 10, 17, 11, 1, 17, 289, DateTimeKind.Local).AddTicks(5663), 5, 18.969999999999999 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "ItemId", "MenuitemId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 3 },
                    { 2, 2, 2, 2, 2 },
                    { 3, 3, 3, 3, 4 },
                    { 4, 4, 4, 4, 1 },
                    { 5, 5, 5, 5, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 1);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "MenuItems",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
