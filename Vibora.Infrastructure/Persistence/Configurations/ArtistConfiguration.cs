using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vibora.Domain.Entities;

namespace Vibora.Infrastructure.Persistence.Configurations;
public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(a => a.Name).IsRequired().HasMaxLength(150);
        builder.Property(a => a.Bio).HasMaxLength(2000);
        builder.Property(a => a.ImageUrl).HasMaxLength(1000);

        builder.HasMany(artist => artist.Albums)
            .WithOne(album => album.Artist) 
            .HasForeignKey(album => album.ArtistId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(artist => artist.Tracks)
            .WithOne()
            .HasForeignKey(track => track.ArtistId) 
            .OnDelete(DeleteBehavior.Cascade);
    }
}