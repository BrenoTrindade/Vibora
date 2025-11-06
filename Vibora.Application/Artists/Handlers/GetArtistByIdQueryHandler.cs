using MediatR;
using Vibora.Application.Artists.Common;
using Vibora.Application.Artists.Queries;
using Vibora.Domain.Exceptions;
using Vibora.Domain.Repositories;

namespace Vibora.Application.Artists.Handlers;

public class GetArtistByIdQueryHandler : IRequestHandler<GetArtistByIdQuery, ArtistResponse>
{
    private readonly IArtistRepository _artistRepository;

    public GetArtistByIdQueryHandler(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }

    public async Task<ArtistResponse> Handle(GetArtistByIdQuery request, CancellationToken cancellationToken)
    {
        var artist = await _artistRepository.GetByIdAsync(request.Id);

        if (artist is null)
        {
            throw new ArtistNotFoundException(request.Id);
        }

        return new ArtistResponse
        {
            Id = artist.Id,
            Name = artist.Name,
            Bio = artist.Bio,
            ImageUrl = artist.ImageUrl,
            AlbumIds = artist.Albums.Select(a => a.Id),
            TrackIds = artist.Tracks.Select(t => t.Id)
        };
    }
}