using FinalAppG.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalAppG.Data.EnitiesConfigration
{
    public class SpecialTripConfig : IEntityTypeConfiguration<SpecialTrip>
    {
        public void Configure(EntityTypeBuilder<SpecialTrip> builder)
        {
            builder
                .HasMany(e => e.Users)
                .WithOne(e => e.specialTrip)
                .HasForeignKey(s => s.specialtripId);
            builder
                .HasOne(e => e.hotel)
                .WithMany(e => e.SpecialTrips)
                .HasForeignKey(s => s.hotelId);



        }
    }
}
