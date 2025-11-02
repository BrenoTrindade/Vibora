namespace Vibora.Domain.Exceptions;
public class TrackNotFoundException : Exception
{
    public TrackNotFoundException(Guid id) : base($"A música com o ID '{id}' não foi encontrada.") { }
}
