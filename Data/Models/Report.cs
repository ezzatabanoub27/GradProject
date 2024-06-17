using System.ComponentModel.DataAnnotations;

namespace FinalAppG.Data.Models
{
    public class Report
    {
        [Key]
        public int Report_Id { get; set; }
        public string? Description { get; set; }
        public DateTime Report_Date { get; set; }

        public List<UserReport> userReports { get; set; } = [];
    }
}
