using FinalAppG.Data;
using FinalAppG.Data.DTOs;
using FinalAppG.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace FinalAppG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly TourismContext _db;
        public ReportController(TourismContext db ) 
        {

            _db = db;
        
        }



        [HttpPost]
        public async Task<IActionResult> addReport( [FromForm]ReportDto dto)
        {
            var report = new Report
            {
                Description = dto.Description,
                Report_Date = dto.Report_Date
            };
            await _db.Reports.AddAsync(report);
            _db.SaveChanges();
            return Ok(report);
        }
    }
}
