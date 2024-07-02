using FinalAppG.Data;
using FinalAppG.Data.DTOs;
using FinalAppG.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalAppG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialTripsController : ControllerBase
    {

        private readonly TourismContext _db;
        public SpecialTripsController(TourismContext db)
        {
            _db = db;  
        }


        [HttpPost("AddSpecialTrip")]

        public async Task<IActionResult> AddSpecialTrip(SpecialTripDto dto)
        {
            SpecialTrip special = new SpecialTrip
            {
                Description = dto.Description,
                GoDate = dto.GoDate,
                BackDate = dto.BackDate,
                Cost = dto.Cost,
                Place = dto.Place,
                Status = dto.Status,
                hotelId = dto.hotelId
            };

            await _db.AddAsync(special);
            _db.SaveChanges();
            return Ok(special);


        }

        [HttpPut("UpdateSpecialTrip {id}")]

        public async Task<IActionResult> UpdateSpecialTrip(int id, [FromBody] SpecialTrip dto)
        {
            var c = await _db.SpecialTrips.SingleOrDefaultAsync(x => x.SpecialTrip_Id == id);
            if (c == null)
            {
                return NotFound("The Special Trip Not Exist");

            }
            c.Description = dto.Description;
            c.GoDate = dto.GoDate;
            c.BackDate = dto.BackDate;
            c.Cost = dto.Cost;
            c.Place = dto.Place;
            c.Status = dto.Status;
            c.hotelId = dto.hotelId;

            _db.SaveChanges();
            return Ok(c);

        }



        [HttpDelete("DeletSpecialTrip{id}")]

        public async Task<IActionResult> DeleteSpecialTrip(int id)
        {
            var result = await _db.SpecialTrips.SingleOrDefaultAsync(x => x.SpecialTrip_Id == id);
            if (result == null)
            {
                return NotFound("no special trip with that id ");
            }

            _db.Remove(result);
            _db.SaveChanges();
            return Ok(result);

        }



        [HttpGet("GetAllSpecialTrips")]
        public async Task<IActionResult> etAll()
        {
            var reuslt = await _db.SpecialTrips.ToListAsync();
            return Ok(reuslt);
        }
        
    }
}
