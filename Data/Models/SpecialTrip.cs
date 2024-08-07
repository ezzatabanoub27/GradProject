﻿using System.ComponentModel.DataAnnotations;

namespace FinalAppG.Data.Models
{
    public class SpecialTrip:ITrip
    {
        [Key]
        public int SpecialTrip_Id { get; set; }
        public string? Description { get; set; }
        public DateTime GoDate { get; set; }
        public DateTime BackDate { get; set; }
        public double Cost { get; set; }
        public string? Place { get; set; }
        public string Status { get; set; }

        public int? hotelId { get; set; }
        public Hotel hotel { get; set; } = null!;

       public ICollection<AppUser> Users { get; }=new List<AppUser>();
        public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();


    }
}
