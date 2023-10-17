using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class Add_Proc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        CREATE PROCEDURE GetCustomersWithLargeReservations
            @minPartySize INT
        AS
        BEGIN
            SELECT DISTINCT c.CustomerId, c.FirstName, c.LastName
            FROM Customers c
            INNER JOIN Reservations r ON c.CustomerId = r.CustomerId
            WHERE r.PartySize > @minPartySize;
        END
    ");
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE GetCustomersWithPartySizeGreaterThan");
        }
    }
}
