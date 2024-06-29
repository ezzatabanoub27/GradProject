using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FinalAppG.Data.Models
{
    public class AppUser:IdentityUser
    {
        [MaxLength(50)]

        public string FName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LName { get; set; }
        [Required]
        public string? Government { get; set; }

        [MaxLength(255)]
        public string? Address { get; set; }
        public string Gender { get; set; }

        public string  Password { get; set; }
        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public int? jobId { get; set; }
        public Job? job { get; set; } = null!;

        public int? specialtripId {  get; set; }
        public SpecialTrip? specialTrip { get; set; } = null!;

        public List<UserFeedBack> userFeedBacks { get; set; } = [];
        public List<UserReport> userReports { get; set; } = [];
        public List<UserTrip> userTrips { get; set; } = [];
        
    }
}
