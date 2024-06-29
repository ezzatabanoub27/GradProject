using System.ComponentModel.DataAnnotations;

namespace FinalAppG.Data.Models
{
    public class UserReport
    {
        [Key]
        public int Id { get; set; } 
        public string  userId { get; set; }
        public int reportId { get; set; }

        public AppUser user { get; set; } = null!;
        public Report report { get; set; } = null!;
    }
}
