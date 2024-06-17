using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;

namespace FinalAppG.Data.Models
{
    public class CarDriverTrip
    {
        [Key]
        public int Id { get; set; }

        public int carId { get; set; }
        public int driverId { get; set; }
        public int tripId { get; set; }

        public Car car { get; set; } = null!;
        public Driver driver { get; set; }=null!;
        public Trip trip { get; set; } = null!;
    }
}
