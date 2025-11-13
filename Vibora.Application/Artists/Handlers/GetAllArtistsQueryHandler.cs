using MediatR;
using Vibora.Application.Artists.Common;
using Vibora.Application.Artists.Queries;
using Vibora.Domain.Repositories;

namespace Vibora.Application.Artists.Handlers;

public class GetAllArtistQueryHandler : IRequestHandler<GetAllArtistsQuery, IEnumerable<ArtistResponse>>
{
    private readonly IArtistRepository _artistRepository;

    public GetAllArtistQueryHandler(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }

    public async Task<IEnumerable<ArtistResponse>> Handle(GetAllArtistsQuery request, CancellationToken cancellationToken)
    {
        var artists = await _artistRepository.GetAllAsync();

        return artists.Select(artist => new ArtistResponse
        {
            Id = artist.Id,
            Name = artist.Name,
            Bio = artist.Bio,
            ImageUrl = artist.ImageUrl,
            AlbumIds = artist.Albums.Select(a => a.Id),
            TrackIds = artist.Tracks.Select(t => t.Id)
        });
    }
}