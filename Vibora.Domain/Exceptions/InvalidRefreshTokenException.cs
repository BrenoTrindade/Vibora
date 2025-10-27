namespace Vibora.Domain.Exceptions;
public class InvalidRefreshTokenException : Exception
{
    public InvalidRefreshTokenException() : base("Refresh token inválido ou expirado.") { }
}