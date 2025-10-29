namespace Vibora.Domain.Entities;
public class Track
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string AudioUrl { get; private set; }
    public TimeSpan Duration { get; private set; }
    public Guid ArtistId {  get; private set; }
    public Guid? AlbumId { get; private set; }

    public Track(string title, string audioUrl, TimeSpan duration, Guid artistId, Guid? albumId)
    {
        Id = Guid.NewGuid();
        Title = title;
        AudioUrl = audioUrl;
        Duration = duration;
        ArtistId = artistId;
        AlbumId = albumId;

        Validate();
    }
    private Track() { }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Title)) 
            { throw new ArgumentException("O título da música é obrigatório."); }
        if (string.IsNullOrWhiteSpace(AudioUrl)) 
            { throw new ArgumentException("O arquivo da música é obrigatório."); }
        if (ArtistId == Guid.Empty)
            { throw new ArgumentException("O autor da música é obrigatório."); }
        if (Duration.TotalSeconds == 0)
            { throw new ArgumentException("A duração da música é obrigatória."); }
    }
}