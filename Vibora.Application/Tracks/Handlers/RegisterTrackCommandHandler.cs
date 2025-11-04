using MediatR;
using Vibora.Application.Tracks.Commands;
using Vibora.Application.Tracks.Common;
using Vibora.Domain.Entities;
using Vibora.Domain.Repositories;

namespace Vibora.Application.Tracks.Handlers;
public class RegisterTrackCommandHandler : IRequestHandler<RegisterTrackCommand, Guid>
{
	private readonly ITrackRepository _repository;
	public RegisterTrackCommandHandler(ITrackRepository repository)
	{
		_repository = repository;
	}

    public async Task<Guid> Handle(RegisterTrackCommand request, CancellationToken cancellationToken)
    {
		var track = new Track(request.Title, request.AudioUrl, request.Duration, request.ArtistId, request.AlbumId);

		await _repository.Add(track);

		return track.Id;
	}
}