using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class Add_fn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"
                CREATE FUNCTION dbo.CalculateTotalRevenue(@restaurantId INT)
                RETURNS DECIMAL(18, 2)
                AS
                BEGIN
                    DECLARE @totalRevenue DECIMAL(18, 2);
                    SELECT @totalRevenue = SUM(o.TotalAmount)
                    FROM Orders o
                    JOIN Reservations r ON o.ReservationId = r.ReservationId
                    WHERE r.RestaurantId = @restaurantId;
                    RETURN @totalRevenue;
                END
                "
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION dbo.CalculateTotalRevenue");
        }
    }
}
