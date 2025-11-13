using MediatR;

namespace Vibora.Application.Albums.Commands;

public class DeleteAlbumCommand : IRequest<Unit>
{
    public Guid Id { get; }

    public DeleteAlbumCommand(Guid id)
    {
        Id = id;
    }
}