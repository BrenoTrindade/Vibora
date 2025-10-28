using MediatR;
using Vibora.Application.Common.Interfaces;
using Vibora.Application.Users.Commands;
using Vibora.Application.Users.Common;
using Vibora.Domain.Entities;
using Vibora.Domain.Repositories;

namespace Vibora.Application.Users.Handlers;
public class AuthenticateWithGoogleCommandHandler : IRequestHandler<AuthenticateWithGoogleCommand, AuthenticationResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public AuthenticateWithGoogleCommandHandler(
        IUserRepository userRepository,
        IJwtTokenGenerator jwtTokenGenerator,
        IRefreshTokenRepository refreshTokenRepository)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<AuthenticationResponse> Handle(AuthenticateWithGoogleCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(command.Email);

        if (user is null)
        {
            var dummyPasswordHash = $"EXTERNAL_AUTH_GOOGLE_{command.GoogleId}";

            user = new User(command.Name, command.Email, dummyPasswordHash);


            await _userRepository.AddAsync(user);
        }

        var Token = _jwtTokenGenerator.GenerateToken(user);
        var refreshTokenString = _jwtTokenGenerator.GenerateRefreshToken();

        var refreshToken = new RefreshToken(
            user.Id,
            refreshTokenString,
            DateTime.UtcNow.AddDays(7),
            DateTime.UtcNow
        );
        await _refreshTokenRepository.AddAsync(refreshToken);

        // 5. Retorne os tokens do Vibora
        return new AuthenticationResponse
        {
            Token = Token,
            RefreshToken = refreshTokenString
        };
    }
}