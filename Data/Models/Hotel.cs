using System.ComponentModel.DataAnnotations;

namespace FinalAppG.Data.Models
{
    public class Hotel
    {
        [Key]
        public int Hotel_Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public int Phone { get; set; }
        public string? Description { get; set; }
        public int? Avilable_single_Rooms { get; set; }
        public int? Avilable_double_Rooms { get; set; }
        public double? Day_Double_Cost { get; set; }
        public double? Day_Single_Cost { get; set; }
        public int Rating { get; set; }
        public string? Photo1URL { get; set; }
        public string? Photo2URL { get; set; }
        public string? photot3Url { get; set; }
        public bool Has_SwimmingPool { get; set; }
        public bool Has_SeeView { get; set; }
        public bool Has_Free_Wifi { get; set; }
        public bool Has_Sports_Gym { get; set; }

       public virtual ICollection<SpecialTrip> SpecialTrips { get; }= new List<SpecialTrip>();

        public virtual ICollection<Booking> Bookings { get; }= new List<Booking>();
        public virtual ICollection<Trip> trips { get; }=new List<Trip>();
    }
}
