using MediatR;
using Vibora.Application.Albums.Commands;
using Vibora.Domain.Exceptions;
using Vibora.Domain.Repositories;

namespace Vibora.Application.Albums.Handlers;

public class DeleteAlbumCommandHandler : IRequestHandler<DeleteAlbumCommand, Unit>
{
    private readonly IAlbumRepository _albumRepository;

    public DeleteAlbumCommandHandler(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }

    public async Task<Unit> Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
    {
        var album = await _albumRepository.GetByIdAsync(request.Id);
        if (album is null)
        {
            throw new ArtistNotFoundException(request.Id);
        }

        await _albumRepository.DeleteAsync(album);

        return Unit.Value;
    }
}