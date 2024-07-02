using FinalAppG.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalAppG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackUserController : ControllerBase
    {

        private readonly TourismContext _db;
        public FeedBackUserController (TourismContext db)
        {
            _db = db;
        }


        [HttpGet("get user feedback   {id}")]

        public async Task <IActionResult> GetUserFeedback(int id )
        {
            var userfeed = await _db.UserFeedBacks.FindAsync(id);

            if (userfeed == null)
            {
                return NotFound("Not Found id ");
            }
            return Ok(userfeed);

        }
    }
}
