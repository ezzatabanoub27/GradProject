using System.ComponentModel.DataAnnotations;

namespace FinalAppG.Data.Models
{
    public class FeedBack
    {
        [Key]
        public int FeedBack_Id { get; set; }
        public string Description { get; set; }
        public DateTime FB_Date { get; set; }

        public List<UserFeedBack> userFeedBacks { get; set; } = [];
        public List<TripFeedback> tripFeedbacks { get; set; } = [];
    }
}
