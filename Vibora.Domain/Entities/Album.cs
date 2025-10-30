namespace Vibora.Domain.Entities;

public class Album
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public int ReleaseYear { get; private set; }
    public string? CoverUrl { get; private set; }
    public Guid ArtistId { get; private set; }
    public Artist Artist { get; private set; } = null!; 
    private readonly List<Track> _tracks = new();
    public IReadOnlyCollection<Track> Tracks => _tracks.AsReadOnly();

    public Album(string title, int releaseYear, Guid artistId, string? coverUrl)
    {
        Id = Guid.NewGuid();
        Title = title;
        ReleaseYear = releaseYear;
        ArtistId = artistId;
        CoverUrl = coverUrl;

        Validate();
    }

    private Album() { }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Title))
            { throw new ArgumentException("O título do álbum é obrigatório.");}

        if (ArtistId == Guid.Empty)
            { throw new ArgumentException("O artista do álbum é obrigatório.");}

        if (ReleaseYear <= 1800 || ReleaseYear > DateTime.UtcNow.Year + 1)
            { throw new ArgumentException("O ano de lançamento é inválido.");}
    }
}