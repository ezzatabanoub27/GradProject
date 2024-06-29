using FinalAppG.Data;
using FinalAppG.Data.DTOs;
using FinalAppG.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace FinalAppG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        private readonly TourismContext _db;

        public FeedBackController(TourismContext db)
        {
            _db = db;
        }


       


        [HttpPost]

        public async Task <IActionResult> AddFeedBack( FeedBackDto dto )
        {
            var feedback = new FeedBack
            {
                Description = dto.Description,
                FB_Date = dto.FB_Date
            };

            await _db.AddAsync(feedback);
            _db.SaveChanges();
            return Ok(feedback);


        }
    }
}
