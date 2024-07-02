using FinalAppG.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalAppG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly TourismContext _db;

        public TripsController(TourismContext db )
        {
            _db= db;

        }

        [HttpGet("get all")]
        public async Task <IActionResult> GetAllTrips()
        {
            var AllTrips = await _db.Trips.ToListAsync();
            return Ok(AllTrips);
        }




    }
}
