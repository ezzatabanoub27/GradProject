using FinalAppG.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalAppG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {

        private readonly TourismContext _db;

        public JobsController(TourismContext db )
        {
            _db =db;

        }

        [HttpGet("getAllJobs")]

        public async Task<IActionResult>GetAllJobs()
        {
            var jobs = await _db.Jobs.ToListAsync();
            return Ok(jobs);
        }



    }
}
