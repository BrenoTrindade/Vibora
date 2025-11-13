namespace Vibora.Domain.Exceptions;
public class AlbumNotFoundException : Exception
{
    public AlbumNotFoundException(Guid id) : base($"O álbum com o ID '{id}' não foi encontrado.") { }
}
