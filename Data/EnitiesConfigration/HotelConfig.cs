using FinalAppG.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalAppG.Data.EnitiesConfigration
{
    public class HotelConfig : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder
                .HasMany(e => e.SpecialTrips)
                .WithOne(e => e.hotel)
                .HasForeignKey(s => s.hotelId);


            builder
                .HasMany(e => e.trips)
                .WithOne(e => e.hotel)
                .HasForeignKey(s => s.hotelId);
        }
    }
}
