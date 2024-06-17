using System.ComponentModel.DataAnnotations;

namespace FinalAppG.Data.Models
{
    public class UserReport
    {
        [Key]
        public int Id { get; set; } 
        public int userId { get; set; }
        public int reportId { get; set; }

        public User user { get; set; } = null!;
        public Report report { get; set; } = null!;
    }
}
