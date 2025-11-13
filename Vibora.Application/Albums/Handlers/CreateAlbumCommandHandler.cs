using MediatR;
using Vibora.Application.Albums.Commands;
using Vibora.Domain.Entities;
using Vibora.Domain.Repositories;

namespace Vibora.Application.Albums.Handlers;

public class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, Guid>
{
    private readonly IAlbumRepository _albumRepository;

    public CreateAlbumCommandHandler(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }

    public async Task<Guid> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
    {
        var album = new Album(
            request.Title,
            request.ReleaseYear,
            request.ArtistId,
            request.CoverUrl
        );

        await _albumRepository.AddAsync(album);

        return album.Id;
    }
}