using MediatR;
using Vibora.Application.Users.Common;

namespace Vibora.Application.Users.Commands;
public class RefreshTokenCommand : IRequest<AuthenticationResponse>
{
    public string Token { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}
