using MediatR;
using Vibora.Application.Tracks.Common;

namespace Vibora.Application.Tracks.Queries;
public record GetTrackByIdQuery(Guid Id) : IRequest<TrackResponse>;