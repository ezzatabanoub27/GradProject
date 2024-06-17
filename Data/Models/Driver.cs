using System.ComponentModel.DataAnnotations;

namespace FinalAppG.Data.Models
{
    public class Driver
    {
        [Key]
        public int Driver_Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public int Phone { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfAppointmentIn { get; set; }
        public string? Email { get; set; }

        public List<CarDriverTrip> carDriverTrips { get; set; } = [];
    }
}
