using System.ComponentModel.DataAnnotations;

namespace FinalAppG.Data.Models
{
    public class TripFeedback
    {
        [Key]
        public int Id { get; set; }

        public int tripId { get; set; }
        public int feedbackId { get; set; }

        public Trip trip { get; set; } = null!;
        public FeedBack feedback { get; set; }=null!;

    }
}
