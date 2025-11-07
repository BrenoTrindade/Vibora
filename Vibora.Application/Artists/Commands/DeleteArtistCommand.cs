using MediatR;

namespace Vibora.Application.Artists.Commands;

public class DeleteArtistCommand : IRequest<Unit>
{
    public Guid Id { get; }

    public DeleteArtistCommand(Guid id)
    {
        Id = id;
    }
}