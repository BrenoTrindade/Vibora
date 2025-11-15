using MediatR;

namespace Vibora.Application.Artists.Commands;

public class UpdateArtistCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Name { get; init; } = string.Empty;
    public string? Bio { get; init; }
    public string? ImageUrl { get; init; }
}