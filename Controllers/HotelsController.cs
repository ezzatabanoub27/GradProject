using FinalAppG.Data;
using FinalAppG.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic;

namespace FinalAppG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly TourismContext _db;
        public HotelsController(TourismContext db)
        {
            _db = db;
        }

        [HttpGet("AllHotels")]
        public async Task<IActionResult> GetAllHotels()
        {
            var AllHotels = await _db.Hotels.OrderBy(g=> g.Name).ToListAsync();
                return Ok(AllHotels);
        }

        [HttpGet("Swimming pool ")]

        public async Task <IActionResult> GetSwimming()
        {
            var swimmeH = await _db.Hotels.Where(o=> o.Has_SwimmingPool==true ).OrderBy(g=>g.Name).ToListAsync();
            return Ok(swimmeH);
        }

        [HttpGet("Free Wifi ")]
        public async Task<IActionResult> GetWifi()
        {
            var wifiH = await _db.Hotels.Where(o=> o.Has_Free_Wifi==true).OrderBy(g=> g.Name).ToListAsync();
            return Ok(wifiH);

        }

        [HttpGet("See View ")]
        public async Task <IActionResult> GetSee()
        {
            var SeeH = await _db.Hotels.Where(o=> o.Has_SeeView==true).OrderBy(g => g.Name).ToListAsync();
            return Ok(SeeH);

        }

        [HttpGet("Sports Gym")]
        public async Task<IActionResult> GetSports()
        {
            var sportsH = await _db.Hotels.Where(o=> o.Has_Sports_Gym==true).OrderBy(g => g.Name).ToListAsync();
            return Ok(sportsH);
        }

        [HttpGet("search")]

        public async Task<ActionResult<IEnumerable<Hotel>>>GetSearch(string query)
        {


            if (string.IsNullOrWhiteSpace(query))
                return await _db.Hotels.ToListAsync();
            var result = await _db.Hotels.Where(i => i.Name.Contains(query) || i.Description.Contains(query)).ToListAsync();
            return Ok(result);
        }
        
    }
}
