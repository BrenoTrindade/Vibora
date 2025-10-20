using MediatR;
using Vibora.Application.Common.Interfaces;
using Vibora.Application.Users.Commands;
using Vibora.Domain.Entities;
using Vibora.Domain.Repositories;

namespace Vibora.Application.Users.Handlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasherService _passwordHasherService;

    public RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasherService passwordHasherService)
    {
        _userRepository = userRepository;
        _passwordHasherService = passwordHasherService;
    }

    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _passwordHasherService.HashPassword(request.Password);

        var user = new User(request.Name, request.Email, passwordHash);

        await _userRepository.AddAsync(user);

        return user.Id;
    }
}

