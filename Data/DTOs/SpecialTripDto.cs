namespace FinalAppG.Data.DTOs
{
    public class SpecialTripDto
    {
        public string? Description { get; set; }
        public DateTime GoDate { get; set; }
        public DateTime BackDate { get; set; }
        public double Cost { get; set; }
        public string? Place { get; set; }
        public string Status { get; set; }

        public int? hotelId { get; set; }


    }
}
