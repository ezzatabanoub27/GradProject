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
                
                var hotel = _db.Hotels.Find(trip.hotelId);
                if (hotel == null) { continue; }
                if (booking.Hotels.Contains(hotel))
                {
                    continue;
                }

                booking.Hotels.Add(hotel);

                if (dto.isSingle) {
                    hotel.Avilable_single_Rooms -= dto.rooms;
                } else {
                    hotel.Avilable_double_Rooms -= dto.rooms;
                }
            }


            var specialTripIds = dto.specialTripIds;
            foreach(var specialTripId in specialTripIds)
            {
                var specialTrip = _db.SpecialTrips.Find(specialTripId);
                if (specialTrip == null)
                {
                    continue;
                }
                booking.SpecialTrips.Add(specialTrip);

                var hotel = _db.Hotels.Find(specialTrip.hotelId);
                if (hotel == null) { continue; }
                if (booking.Hotels.Contains(hotel))
                {
                    continue;
                }

                booking.Hotels.Add(hotel);

                if (dto.isSingle)
                {
                    hotel.Avilable_single_Rooms -= dto.rooms;
                }
                else
                {
                    hotel.Avilable_double_Rooms -= dto.rooms;
                }
            }

            await _db.Bookings.AddAsync(booking);
            _db.SaveChanges();
            return Ok(booking);
        }
       

    }
}
