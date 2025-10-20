using MediatR;
using Vibora.Application.Users.Common;

namespace Vibora.Application.Users.Queries;
public record GetUserByIdQuery(Guid Id) : IRequest<UserResponse>;