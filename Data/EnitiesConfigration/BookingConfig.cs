using FinalAppG.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalAppG.Data.EnitiesConfigration
{
    public class BookingConfig : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            //builder
            //    .HasOne(e => e.hotel)
            //    .WithMany(e => e.Bookings)
            //    .HasForeignKey(s => s.hotelId);
            //builder
            //    .HasOne(e => e.trip)
            //    .WithMany(e => e.Bookings)
            //    .HasForeignKey(s => s.tripId);
            //builder
            //  .HasOne(e => e.specialTrip)
            //  .WithMany(e => e.Bookings)
            //   .HasForeignKey(s => s.specialTripId);
        }
    }
}
