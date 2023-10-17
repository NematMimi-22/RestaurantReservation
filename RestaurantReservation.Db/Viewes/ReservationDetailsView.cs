namespace RestaurantReservation.Db.Viewes
{
    public class ReservationDetailsView
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
