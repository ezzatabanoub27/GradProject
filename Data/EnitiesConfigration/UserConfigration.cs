﻿using FinalAppG.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalAppG.Data.EnitiesConfigration
{
    public class UserConfigration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder
                .HasOne(e => e.job)
                .WithMany(e => e.Users)
                .HasForeignKey(s => s.jobId);


            builder
                .HasOne(e => e.specialTrip)
                .WithMany(e => e.Users)
                .HasForeignKey(s => s.specialtripId);

        }
    }
}
