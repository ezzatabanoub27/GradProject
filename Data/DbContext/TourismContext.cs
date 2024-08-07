
﻿using FinalAppG.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
﻿using FinalAppG.Data.EnitiesConfigration;
using FinalAppG.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalAppG.Data
{
    public class TourismContext:IdentityDbContext<AppUser>
    {
        public TourismContext(DbContextOptions<TourismContext> options): base(options) 
        { 


        }
        public DbSet<UserTrip> UserTrips { get; set; }
        public DbSet<UserReport> UserReports { get; set; }
        public DbSet<UserFeedBack> UserFeedBacks { get; set; }
        public DbSet<TripFeedback> TripFeedbacks { get; set; }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<TourGuid> TourGuids { get; set; }
        public DbSet<SpecialTrip> SpecialTrips { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet <CarDriverTrip> CarDriverTrips { get; set; }
        public DbSet<Car> Cars {  get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookingConfig());
            modelBuilder.ApplyConfiguration(new HotelConfig());
            base.OnModelCreating(modelBuilder);

        }

    }    
}
