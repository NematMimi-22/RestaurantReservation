﻿namespace RestaurantReservationAPI.DTO
{
    public class MenuItemDTO
    {
        public int MenuItemId { get; set; }
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}