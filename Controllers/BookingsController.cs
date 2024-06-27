using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalAppG.Data;
using FinalAppG.Data.Models;
using FinalAppG.Data.DTOs;

namespace FinalAppG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BookingsController : ControllerBase
    { 
    
    private readonly TourismContext _db;

    public BookingsController(TourismContext db)
        {
            _db = db;
        }

        [HttpGet("all Bookings")]
        public async Task<IActionResult> GetAllBookings()
        {
            var Bookings = await _db.Bookings.ToListAsync();
            return Ok(Bookings);
        }

        [HttpPost]

        public async Task<IActionResult> AddBooking(BookingDTO dto)
        {
            var booking = new Booking
            {
                Price = dto.Price,
                BookTime = dto.BookTime,
                Duration = dto.Duration,
                IsBooked = dto.IsBooked
            };

            var tripIds = dto.tripIds;
            foreach (var tripid in tripIds)
            {
                var trip = _db.Trips.Find(tripid);
                if (trip == null)
                {
                    continue;
                }
                booking.Trips.Add(trip);
            }



            await _db.Bookings.AddAsync(booking);
            _db.SaveChanges();
            return Ok(booking);
        }
       

    }
}
