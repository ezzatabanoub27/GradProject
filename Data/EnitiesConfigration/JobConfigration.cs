using FinalAppG.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalAppG.Data.EnitiesConfigration
{
    public class JobConfigration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {

            builder
               .HasMany(e => e.Users)
               .WithOne(e => e.job)
               .HasForeignKey(s => s.jobId);

               
                
        }
    }
}
