using FinalAppG.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalAppG.Data.EnitiesConfigration
{
    public class BookingConfig : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasMany(b => b.Trips)
                    .WithMany(t => t.Bookings)
                    .UsingEntity<Dictionary<string, object>>(
                        "BookingTrip",
                        j => j.HasOne<Trip>()
                                .WithMany()
                                .HasForeignKey("Trip_Id"),
                        j => j.HasOne<Booking>()
                                .WithMany()
                                .HasForeignKey("BookingsId"));

            
        }
    }
}
