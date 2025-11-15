using MediatR;
using Vibora.Application.Artists.Commands;
using Vibora.Application.Artists.Common;
using Vibora.Domain.Exceptions;
using Vibora.Domain.Repositories;

namespace Vibora.Application.Artists.Handlers;

public class UpdateArtistCommandHandler : IRequestHandler<UpdateArtistCommand, Unit>
{
    private readonly IArtistRepository _artistRepository;
    public UpdateArtistCommandHandler(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }

    public async Task<Unit> Handle(UpdateArtistCommand request, CancellationToken cancellationToken)
    {
        var artist = await _artistRepository.GetByIdAsync(request.Id);

        if (artist is null)
        {
            throw new ArtistNotFoundException(request.Id);
        }

        artist.Update(request.Name, request.Bio, request.ImageUrl);

        await _artistRepository.UpdateAsync(artist);

        return Unit.Value;
    }
}