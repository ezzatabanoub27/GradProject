using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;

namespace FinalAppG.Data.Models
{
    public class UserTrip
    {
        [Key]
        public int Id { get; set; }
        public string  userId { get; set; }
        public int tripId { get; set; }


        public AppUser user { get; set; } = null!;
        public Trip trip { get; set; } = null!;
    }
}
