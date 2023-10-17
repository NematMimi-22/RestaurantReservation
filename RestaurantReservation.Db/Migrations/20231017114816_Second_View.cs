using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class Second_View : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW EmployeeRestaurantDetailsView AS
                         SELECT 
                            e.EmployeeId,
                            e.FirstName,
                            e.LastName,
                            e.Position,
                            r.Name AS RestaurantName,
                            r.Address AS RestaurantAddress
                         FROM Employees e
                         INNER JOIN Restaurants r ON e.RestaurantId = r.RestaurantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW EmployeeRestaurantDetailsView");
        }

    }
}