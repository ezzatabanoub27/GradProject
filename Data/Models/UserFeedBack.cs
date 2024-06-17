using System.ComponentModel.DataAnnotations;

namespace FinalAppG.Data.Models
{
    public class UserFeedBack
    {
        [Key]
        public int Id { get; set; }
        public int userId { get; set; }
        public int feedBackId { get; set; }
        public User user { get; set; } = null!;
        public FeedBack FeedBack { get; set; } = null!;

    }
}
