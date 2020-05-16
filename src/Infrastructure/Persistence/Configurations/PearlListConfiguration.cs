
using PearlsOfWisdom.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PearlsOfWisdom.Infrastructure.Persistence.Configurations
{
    public class PearlListConfiguration : IEntityTypeConfiguration<PearlList>
    {
        public void Configure(EntityTypeBuilder<PearlList> builder)
        {
            builder.Property(t => t.Title)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
