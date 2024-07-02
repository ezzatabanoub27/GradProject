namespace FinalAppG.Data.DTOs
{
    public class BookingSpecialTripDTO
    {
        public float Price { get; set; }
        public DateTime BookTime { get; set; }
        public int Duration { get; set; }
        public bool IsBooked { get; set; }

        public bool isSingle { get; set; }
        public int rooms { get; set; }

        public int? specialTripId { get; set; }

    }
}
