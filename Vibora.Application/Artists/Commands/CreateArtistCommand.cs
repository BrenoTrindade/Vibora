using MediatR;

namespace Vibora.Application.Artists.Commands;

public class CreateArtistCommand : IRequest<Guid>
{
    public string Name { get; init; } = string.Empty;
    public string? Bio { get; init; }
    public string? ImageUrl { get; init; }
}