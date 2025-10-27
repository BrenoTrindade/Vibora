using MediatR;
using Vibora.Application.Users.Common;

namespace Vibora.Application.Users.Queries;

public class LoginQuery: IRequest<AuthenticationResponse>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
