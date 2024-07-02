using FinalAppG.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalAppG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportUserController : ControllerBase
    {
        private readonly TourismContext _db;
        public ReportUserController (TourismContext db)
        {
            _db = db;
        }

        [HttpGet("get user report {id}")]

        public async Task <IActionResult> getuserreport(int id)
        {
            var reportuser = await _db.UserReports.FindAsync(id);
            if (reportuser == null)
            {
                return NotFound("Not Fpund Report ");

            }

            return Ok(reportuser);
        }

    }
}
