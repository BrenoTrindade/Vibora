using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vibora.Application.Artists.Queries;
using Vibora.Domain.Exceptions;

namespace Vibora.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArtistsController : ControllerBase
{
    private readonly ISender _mediator;

    public ArtistsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:Guid}")]
    [Authorize] 
    public async Task<IActionResult> GetArtistById(Guid id)
    {
        try
        {
            var query = new GetArtistByIdQuery(id);
            var artist = await _mediator.Send(query);
            return Ok(artist);
        }
        catch (ArtistNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}