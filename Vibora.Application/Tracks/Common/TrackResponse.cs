using MediatR;

namespace Vibora.Application.Tracks.Common;

public class TrackResponse
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string AudioUrl { get; init; }
    public TimeSpan Duration { get; init; }
    public Guid ArtistId { get; init; }
    public Guid? AlbumId { get; init; }
}