using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class First_View : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW ReservationDetailsView AS
                          SELECT 
                             r.ReservationId,
                             r.CustomerId,
                             c.FirstName AS CustomerFirstName,
                             c.LastName AS CustomerLastName,
                             r.RestaurantId,
                             res.Name AS RestaurantName,
                             res.Address AS RestaurantAddress,
                             r.ReservationDate
                          FROM Reservations r
                          INNER JOIN Customers c ON r.CustomerId = c.CustomerId
                          INNER JOIN Restaurants res ON r.RestaurantId = res.RestaurantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW ReservationDetailsView");
        }
    }
}