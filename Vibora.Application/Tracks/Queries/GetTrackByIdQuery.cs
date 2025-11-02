using MediatR;
using Vibora.Application.Users.Common;

namespace Vibora.Application.Users.Queries;
public record GetTrackByIdQuery(Guid Id) : IRequest<TrackResponse>;