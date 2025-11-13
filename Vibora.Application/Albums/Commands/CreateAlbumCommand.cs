using MediatR;

namespace Vibora.Application.Albums.Commands;

public class CreateAlbumCommand : IRequest<Guid>
{
    public string Title { get; init; } = string.Empty;
    public int ReleaseYear { get; init; }
    public Guid ArtistId { get; init; }
    public string? CoverUrl { get; init; }

}