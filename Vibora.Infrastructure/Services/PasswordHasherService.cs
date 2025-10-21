using Vibora.Application.Common.Interfaces;

namespace Vibora.Infrastructure.Services;

public class PasswordHasherService : IPasswordHasherService
{
    public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
    public bool VerifyPassword(string password, string hash) => BCrypt.Net.BCrypt.Verify(password, hash);
}
