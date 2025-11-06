namespace Vibora.Application.Artists.Common;

public class ArtistResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? Bio { get; init; }
    public string? ImageUrl { get; init; }
    public IEnumerable<Guid> AlbumIds { get; init; } = Enumerable.Empty<Guid>();
    public IEnumerable<Guid> TrackIds { get; init; } = Enumerable.Empty<Guid>();
}