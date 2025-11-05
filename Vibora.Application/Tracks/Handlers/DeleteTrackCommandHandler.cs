using MediatR;
using Vibora.Application.Tracks.Commands;
using Vibora.Domain.Entities;
using Vibora.Domain.Exceptions;
using Vibora.Domain.Repositories;

namespace Vibora.Application.Tracks.Handlers;

public class DeleteTrackCommandHandler : IRequestHandler<DeleteTrackCommand, Unit>
{
    private readonly ITrackRepository _trackRepository;
    public DeleteTrackCommandHandler(ITrackRepository trackRepository)
    {
        _trackRepository = trackRepository;
    }

    public async Task<Unit> Handle(DeleteTrackCommand request, CancellationToken cancellationToken)
    {
        var track = await _trackRepository.GetById(request.Id);

        if (track is null)
            throw new TrackNotFoundException(request.Id);

        await _trackRepository.Delete(track);

        return Unit.Value;
    }
}