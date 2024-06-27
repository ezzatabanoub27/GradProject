﻿namespace FinalAppG.Data.DTOs
{
    public class BookingDTO
    {
        public float Price { get; set; }
        public DateTime BookTime { get; set; }
        public int? Duration { get; set; }
        public bool? IsBooked { get; set; }

        public int[] tripIds { get; set; }
    }
}