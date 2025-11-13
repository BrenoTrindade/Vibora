using MediatR;
using Vibora.Application.Albums.Common;

namespace Vibora.Application.Albums.Queries;
public class GetAlbumByIdQuery : IRequest<AlbumResponse>
{
    public Guid Id { get; }

    public GetAlbumByIdQuery(Guid id)
    {
        Id = id;
    }
}