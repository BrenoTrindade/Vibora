
using MediatR;
using Vibora.Application.Albums.Common;
using Vibora.Application.Albums.Queries;
using Vibora.Domain.Entities;
using Vibora.Domain.Exceptions;
using Vibora.Domain.Repositories;

namespace Vibora.Application.Albums.Handlers;

public class GetAlbumByIdQueryHandler : IRequestHandler<GetAlbumByIdQuery, AlbumResponse>
{
    private readonly IAlbumRepository _albumRepository;

    public GetAlbumByIdQueryHandler(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }

    public async Task<AlbumResponse> Handle(GetAlbumByIdQuery request, CancellationToken cancellationToken)
    {
        var album = await _albumRepository.GetByIdAsync(request.Id);

        if (album is null)
        {
            throw new AlbumNotFoundException(request.Id);
        }

        return new AlbumResponse
        {
            Id = album.Id,
            Title = album.Title,
            ReleaseYear = album.ReleaseYear,
            ArtistId = album.ArtistId,
            CoverUrl = album.CoverUrl,

            Tracks = [.. album.Tracks.Select(track => new TrackResponse { Id = track.Id, Title = track.Title, DurationInSeconds = track.Duration.Seconds })]
        };
    }
}