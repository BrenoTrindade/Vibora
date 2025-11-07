using MediatR;
using Vibora.Application.Artists.Commands;
using Vibora.Domain.Entities;
using Vibora.Domain.Repositories;

namespace Vibora.Application.Artists.Handlers;

public class CreateArtistCommandHandler : IRequestHandler<CreateArtistCommand, Guid>
{
    private readonly IArtistRepository _artistRepository;

    public CreateArtistCommandHandler(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }

    public async Task<Guid> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
    {
        var artist = new Artist(
            request.Name,
            request.Bio,
            request.ImageUrl
        );

        await _artistRepository.AddAsync(artist);

        return artist.Id;
    }
}