using MediatR;
using Vibora.Application.Artists.Common;

namespace Vibora.Application.Artists.Queries;

public class GetAllArtistsQuery : IRequest<IEnumerable<ArtistResponse>>
{
}