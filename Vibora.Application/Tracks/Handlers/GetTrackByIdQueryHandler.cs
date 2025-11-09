using MediatR;
using Vibora.Application.Tracks.Common;
using Vibora.Application.Tracks.Queries;
using Vibora.Domain.Entities;
using Vibora.Domain.Exceptions;
using Vibora.Domain.Repositories;

namespace Vibora.Application.Tracks.Handlers;

public class GetTrackByIdQueryHandler : IRequestHandler<GetTrackByIdQuery, TrackResponse>
{
    private readonly ITrackRepository _trackRepository;

    public GetTrackByIdQueryHandler(ITrackRepository trackRepository)
    {
        _trackRepository = trackRepository;
    }

    public async Task<TrackResponse> Handle(GetTrackByIdQuery request, CancellationToken cancellationToken)
    {
        var track = await _trackRepository.GetByIdAsync(request.Id);

        if (track is null)
        {
            throw new TrackNotFoundException(request.Id);
        }

        return new TrackResponse
        {
            Id = track.Id,
            Title = track.Title,
            AlbumId = track.AlbumId,
            ArtistId = track.ArtistId,
            AudioUrl = track.AudioUrl,
            Duration = track.Duration
        };
    }
}