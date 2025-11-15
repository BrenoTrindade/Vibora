namespace Vibora.Domain.Entities;
public class Artist
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string? Bio { get; private set; }
    public string? ImageUrl { get; private set; }

    private readonly List<Album> _albums = new();
    public IReadOnlyCollection<Album> Albums => _albums.AsReadOnly();

    private readonly List<Track> _tracks = new();
    public IReadOnlyCollection<Track> Tracks => _tracks.AsReadOnly();

    public Artist(string name, string? bio, string? imageUrl)
    {
        Id = Guid.NewGuid();
        Name = name;
        Bio = bio;
        ImageUrl = imageUrl;

        Validate();
    }
    private Artist() { }

    public void Update(string name, string? bio, string? imageUrl)
    {
        Name = name;
        Bio = bio;
        ImageUrl = imageUrl;

        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new ArgumentException("O nome do artista é obrigatório.");
        }
    }
}
