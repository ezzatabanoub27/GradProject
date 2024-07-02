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

        [HttpPost("Booking a Trip")]

        public async Task<IActionResult> AddBooking(BookingDTO dto)
        {
            var booking = new Booking
            {
                Price = dto.Price,
                BookTime = dto.BookTime,
                Duration = dto.Duration,
                IsBooked = dto.IsBooked,
            };

            var tripId = dto.tripId;
            var trip = _db.Trips.Find(tripId);
            if (trip == null)
            {
                return BadRequest(new { message = "Couldn't Find trip with Id: " + tripId });
            }
            booking.Trips.Add(trip);

            var Result = handleBookingHotel(booking, trip, dto);
            if (!Result.Item1)
            {
                return BadRequest(new { message = Result.Item2 });
            }
             
            await _db.Bookings.AddAsync(booking);
            _db.SaveChanges();
            return Ok(booking);
        }
        
        [HttpPost("Booking a SpeciaLTrip")]
        public async Task<IActionResult> AddBookingSpeciaLTrip(BookingSpecialTripDTO dto)
        {
            var booking = new Booking
            {
                Price = dto.Price,
                BookTime = dto.BookTime,
                Duration = dto.Duration,
                IsBooked = dto.IsBooked,

            };

            var SpecialTripId = dto.specialTripId;
            var trip = _db.Trips.Find(SpecialTripId);
            if (trip == null)
            {
                return BadRequest(new { message = "Couldn't Find trip with Id: " + SpecialTripId });
            }
            booking.Trips.Add(trip);

            var Result = handleBooking_s_Hotel(booking, trip, dto);
            if (!Result.Item1)
            {
                return BadRequest(new { message = Result.Item2 });
            }


            await _db.Bookings.AddAsync(booking);
            _db.SaveChanges();
            return Ok(booking);
        }

        private (bool, string) handleBookingHotel(Booking booking, ITrip trip, BookingDTO dto)
        {
            var status = false;
            var error = "";

            var hotel = _db.Hotels.Find(trip.hotelId);
            if (hotel == null || booking.Hotels.Contains(hotel))
            {
                error = "Failed to get the hotel of the trip";
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

            if (hotel.Avilable_single_Rooms < 0
                || hotel.Avilable_double_Rooms < 0)
            {
                error = "The hotel doesn't have enough rooms";
            }

            if (error.Length == 0)
            {
                status = true;
            }
            return (status, error);
        }

        private (bool, string) handleBooking_s_Hotel(Booking booking, ITrip trip, BookingSpecialTripDTO dto)
        {
            var status = false;
            var error = "";

            var hotel = _db.Hotels.Find(trip.hotelId);
            if (hotel == null || booking.Hotels.Contains(hotel))
            {
                error = "Failed to get the hotel of the trip";
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

            if (hotel.Avilable_single_Rooms < 0
                || hotel.Avilable_double_Rooms < 0)
            {
                error = "The hotel doesn't have enough rooms";
            }

            if (error.Length == 0)
            {
                status = true;
            }
            return (status, error);
        }


    }
}