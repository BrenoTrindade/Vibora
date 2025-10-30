using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vibora.Domain.Entities;

namespace Vibora.Infrastructure.Persistence.Configurations;
public class TrackConfiguration : IEntityTypeConfiguration<Track>
{
    public void Configure(EntityTypeBuilder<Track> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Title).IsRequired().HasMaxLength(200);
        builder.Property(t => t.AudioUrl).IsRequired().HasMaxLength(500);
        builder.Property(t => t.Duration).IsRequired();
        builder.HasIndex(t => t.ArtistId);
        builder.HasIndex(t => t.AlbumId);
    }
}