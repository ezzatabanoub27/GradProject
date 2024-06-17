using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;

namespace FinalAppG.Data.Models
{
    public class UserTrip
    {
        [Key]
        public int Id { get; set; }
        public int userId { get; set; }
        public int tripId { get; set; }


        public User user { get; set; } = null!;
        public Trip trip { get; set; } = null!;
    }
}
