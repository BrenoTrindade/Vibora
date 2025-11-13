using MediatR;
using Vibora.Application.Albums.Common;

namespace Vibora.Application.Albums.Queries;

public class GetAllAlbumQuery : IRequest<IEnumerable<AlbumResponse>>
{
}