using System.ComponentModel.DataAnnotations;

namespace FinalAppG.Data.Models
{
    public class TourGuid
    {
        [Key]
        public int TourGuid_Id { get; set; }


        [Required]
        public string Name { get; set; }

        public string? Address { get; set; }
        [MaxLength(10)]
        [Required]
        public string Gender { get; set; }
        public string? Email { get; set; }
        public int? Phone { get; set; }

        public int tripId { get; set; }
        public Trip trip { get; set; }
    }
}
