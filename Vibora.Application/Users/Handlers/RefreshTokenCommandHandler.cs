using MediatR;
using System.Security.Claims;
using Vibora.Application.Common.Interfaces;
using Vibora.Application.Users.Commands;
using Vibora.Application.Users.Common;
using Vibora.Domain.Entities;
using Vibora.Domain.Exceptions;
using Vibora.Domain.Repositories;

namespace Vibora.Application.Users.Handlers;
public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AuthenticationResponse>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUserRepository _userRepository;

    public RefreshTokenCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IRefreshTokenRepository refreshTokenRepository, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _refreshTokenRepository = refreshTokenRepository;
        _userRepository = userRepository;
    }

    public async Task<AuthenticationResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var principal = _jwtTokenGenerator.GetPrincipalFromExpiredToken(request.Token);
        var userIdString = principal?.FindFirst(ClaimTypes.NameIdentifier).Value;
        
        if (userIdString is null || !Guid.TryParse(userIdString, out var userId))
        {
            throw new InvalidRefreshTokenException();
        }

        var storedToken = await _refreshTokenRepository.GetByTokenAsync(request.RefreshToken);
        if (storedToken == null || !storedToken.IsActive || storedToken.UserId != userId)
        {
            throw new InvalidRefreshTokenException();
        }

        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
        {
            throw new InvalidRefreshTokenException();
        }

        storedToken.Revoke();

        var newToken = _jwtTokenGenerator.GenerateToken(user);
        var newRefreshTokenString = _jwtTokenGenerator.GenerateRefreshToken();

        var newRefreshToken = new RefreshToken(user.Id, newRefreshTokenString, DateTime.UtcNow.AddDays(1), DateTime.UtcNow);

        await _refreshTokenRepository.AddAsync(newRefreshToken);

        return new AuthenticationResponse
        {
            Token = newToken,
            RefreshToken = newRefreshTokenString
        };
    }
}