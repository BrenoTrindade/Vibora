namespace Vibora.Domain.Exceptions;
public class UserNotFoundException : Exception
{
    public UserNotFoundException(Guid id) : base($"O usuário com o ID '{id}' não foi encontrado.") { }
}
