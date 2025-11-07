using MediatR;
using Vibora.Application.Artists.Commands;
using Vibora.Domain.Exceptions;
using Vibora.Domain.Repositories;

namespace Vibora.Application.Artists.Handlers;

public class DeleteArtistCommandHandler : IRequestHandler<DeleteArtistCommand, Unit>
{
    private readonly IArtistRepository _artistRepository;

    public DeleteArtistCommandHandler(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }

    public async Task<Unit> Handle(DeleteArtistCommand request, CancellationToken cancellationToken)
    {
        var artist = await _artistRepository.GetByIdAsync(request.Id);
        if (artist is null)
        {
            throw new ArtistNotFoundException(request.Id);
        }

        await _artistRepository.DeleteAsync(artist);

        return Unit.Value;
    }
}