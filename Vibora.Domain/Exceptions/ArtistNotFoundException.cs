namespace Vibora.Domain.Exceptions;

public class ArtistNotFoundException : Exception
{
    public ArtistNotFoundException(Guid id) : base($"O artista com o ID '{id}' não foi encontrado.") { }
}