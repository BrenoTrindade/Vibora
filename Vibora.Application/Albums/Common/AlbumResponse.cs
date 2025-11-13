namespace Vibora.Application.Albums.Common;

public class AlbumResponse
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public int ReleaseYear { get; set; }

    public string? CoverUrl { get; set; }

    public Guid ArtistId { get; set; }

    public ICollection<TrackResponse> Tracks { get; set; } = new List<TrackResponse>();
}

public class TrackResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int DurationInSeconds { get; set; }
}