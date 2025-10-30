using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vibora.Domain.Entities;

namespace Vibora.Infrastructure.Persistence.Configurations;
public class AlbumConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Title).IsRequired().HasMaxLength(200);
        builder.Property(a => a.ReleaseYear).IsRequired();
        builder.Property(a => a.CoverUrl).HasMaxLength(500);
        builder.HasIndex(a => a.ArtistId);

        builder.HasMany(album => album.Tracks)
            .WithOne()
            .HasForeignKey(track => track.AlbumId) 
            .OnDelete(DeleteBehavior.SetNull);
    }
}