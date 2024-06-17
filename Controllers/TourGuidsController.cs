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
    public class TourGuidsController : ControllerBase
    {
        private readonly TourismContext _db;

        public TourGuidsController(TourismContext db )
        {
            _db=db;

        }

        [HttpGet("all Tour Guids ")]


        public async Task<IActionResult> GetAllTours()
        {
            var Tours = await _db.TourGuids.ToListAsync();
            return Ok(Tours);

        }
        [HttpPost]
         public async Task<IActionResult> AddTourGuid(TourGuidDTO dto)
        {

            var tourguid = new TourGuid
            {
                Name = dto.Name,
                Address = dto.Address,
                Phone =  dto.Phone,
                Gender= dto.Gender

            };
            await _db.TourGuids.AddAsync(tourguid);
            _db.SaveChanges();
            return Ok(tourguid);
        }


        [HttpPut(" {id }")]
        public async Task<IActionResult> UpdateAsync(int id , TourGuidDTO dto)
        {
            var tour = await _db.TourGuids.FindAsync(id);
            if (tour == null)
            {
                return NotFound("Not found Tour Guid with id : "+id );
            }
            tour.Name = dto.Name;
            tour.Address = dto.Address;
            tour.Email = dto.Email;
            tour.Phone = dto.Phone;

            _db.SaveChanges();

            return Ok(tour);


        }
    }
}
