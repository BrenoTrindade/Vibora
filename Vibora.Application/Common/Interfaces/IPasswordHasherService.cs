namespace Vibora.Application.Common.Interfaces;
public interface IPasswordHasherService
{
    string HashPassword (string password);
}
