using MediatR;

namespace Vibora.Application.Tracks.Commands;

public class DeleteTrackCommand : IRequest<Unit>
{
    public Guid Id { get; }

    public DeleteTrackCommand(Guid id)
    {
        Id = id;
    }
}