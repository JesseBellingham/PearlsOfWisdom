using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PearlsOfWisdom.Domain.Entities;

namespace PearlsOfWisdom.Infrastructure.Persistence.Configurations
{
    public class KeyPointConfiguration : IEntityTypeConfiguration<KeyPoint>
    {
        public void Configure(EntityTypeBuilder<KeyPoint> builder)
        {
            builder.Property(k => k.Text)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}