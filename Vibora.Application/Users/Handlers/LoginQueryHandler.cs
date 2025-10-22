using MediatR;
using Vibora.Application.Common.Interfaces;
using Vibora.Application.Users.Common;
using Vibora.Application.Users.Queries;
using Vibora.Domain.Exceptions;
using Vibora.Domain.Repositories;

namespace Vibora.Application.Users.Handlers;

public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasherService _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(IUserRepository userRepository, IPasswordHasherService passwordHasher, IJwtTokenGenerator tokenGenerator)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = tokenGenerator;
    }

    public async Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user == null)
        {
            throw new InvalidCredentialsException();
        }

        var isPasswordValid = _passwordHasher.VerifyPassword(request.Password, user.PasswordHash);

        if(!isPasswordValid)
        {
            throw new InvalidCredentialsException();
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new LoginResponse { Token = token };
    }
}