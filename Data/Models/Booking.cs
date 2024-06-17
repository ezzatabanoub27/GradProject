using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace FinalAppG.Data.Models
{
    public class Booking
    {
        [Key]
         public int Id { get; set; }
         public double Price { get; set; }
         public DateTime BookTime { get; set; }
         public int? Duration { get; set; }
         public Boolean? IsBooked { get; set; }

        public virtual ICollection<Hotel> Hotel { get; set; }   
        public virtual ICollection<Trip> Trip { get; set; }
        public virtual ICollection<SpecialTrip> SpecialTrips { get; set; }

    }
}
