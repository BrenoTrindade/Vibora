using MediatR;
using Vibora.Application.Artists.Common;

namespace Vibora.Application.Artists.Queries;

public class GetArtistByIdQuery : IRequest<ArtistResponse>
{
    public Guid Id { get; }

    public GetArtistByIdQuery(Guid id)
    {
        Id = id;
    }
}