using MediatR;

namespace Vibora.Application.Tracks.Commands;

public class RegisterTrackCommand : IRequest<Guid>
{
    public string Title { get; init; }
    public string AudioUrl { get; init; }
    public TimeSpan Duration { get; init; }
    public Guid ArtistId { get; init; }
    public Guid? AlbumId { get; init; }
}