using Vibora.Domain.Entities;

namespace Vibora.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}