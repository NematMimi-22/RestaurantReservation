﻿namespace RestaurantReservationAPI.DTO
{
    public class OrderItemDTO
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int MenuitemId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}