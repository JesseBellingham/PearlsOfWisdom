﻿using PearlsOfWisdom.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PearlsOfWisdom.Infrastructure.Persistence.Configurations
{
    public class PearlItemConfiguration : IEntityTypeConfiguration<PearlItem>
    {
        public void Configure(EntityTypeBuilder<PearlItem> builder)
        {
            builder.Property(t => t.Title)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
