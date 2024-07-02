using System.ComponentModel.DataAnnotations;

namespace FinalAppG.Data.Models
{
    public class Trip:ITrip
    {


        [Key]
        public int Trip_Id { get; set; }



        public string Descripton { get; set; }
        public DateTime GoDate { get; set; }
        public DateTime BackDate { get; set; }
        public double Cost { get; set; }
        public string Status { get; set; }


        public int? hotelId { get; set;}
        public Hotel? hotel { get; set; }
        public List<UserTrip> userTrips { get; set; } = [];
        public List<TripFeedback> tripFeedbacks { get; set; } = [];
        public List<CarDriverTrip> carDriverTrips { get; set; } = [];
        public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();


    }
}
