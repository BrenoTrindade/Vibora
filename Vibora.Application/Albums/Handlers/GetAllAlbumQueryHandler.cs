using MediatR;
using Vibora.Application.Albums.Common;
using Vibora.Application.Albums.Queries;
using Vibora.Domain.Repositories;

namespace Vibora.Application.Artists.Handlers;

public class GetAllAlbumQueryHandler : IRequestHandler<GetAllAlbumQuery, IEnumerable<AlbumResponse>>
{
    private readonly IAlbumRepository _albumRepository;

    public GetAllAlbumQueryHandler(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }

    public async Task<IEnumerable<AlbumResponse>> Handle(GetAllAlbumQuery request, CancellationToken cancellationToken)
    {
        var albums = await _albumRepository.GetAllAsync();

        return albums.Select(album => new AlbumResponse
        {
            Id = album.Id,
            Title = album.Title,
            ReleaseYear = album.ReleaseYear,
            ArtistId = album.ArtistId,
            CoverUrl = album.CoverUrl,
            
            Tracks = [.. album.Tracks.Select(track => new TrackResponse {Id = track.Id, Title = track.Title, DurationInSeconds = track.Duration.Seconds})]
        });
    }
}