using MediatR;
using Vibora.Application.Users.Common;

namespace Vibora.Application.Users.Commands;
public class AuthenticateWithGoogleCommand : IRequest<AuthenticationResponse>
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string GoogleId { get; set; }
}

