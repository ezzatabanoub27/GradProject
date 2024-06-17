using FinalAppG.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalAppG.Data.EnitiesConfigration
{
    public class TripConfig : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder
                .HasOne(e => e.hotel)
                .WithMany(e => e.trips)
                .HasForeignKey(s => s.hotelId);


        }
    }
}
