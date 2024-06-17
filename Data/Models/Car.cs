using System.ComponentModel.DataAnnotations;

namespace FinalAppG.Data.Models
{
    public class Car
    {
        [Key]
        public int Car_Id { get; set; }
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public DateTime ProductionDate { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }


        public List<CarDriverTrip> carDriverTrips { get; set; } = [];
    }
}
