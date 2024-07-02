using System.ComponentModel.DataAnnotations;

namespace FinalAppG.Data.Models
{
    public class UserFeedBack
    {
        [Key]
        public int Id { get; set; }
        public string  userId { get; set; } 
        public int feedBackId { get; set; }
        public AppUser user { get; set; } = null!;
        public FeedBack FeedBack { get; set; } = null!;

    }
}
