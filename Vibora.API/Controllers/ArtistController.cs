using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vibora.Application.Artists.Commands;
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

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllArtists()
    {
        var artists = await _mediator.Send(new GetAllArtistsQuery());
        return Ok(artists);
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

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateArtist([FromBody] CreateArtistCommand command)
    {
        try
        {
            var artistId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetArtistById), new { id = artistId }, new { id = artistId });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpDelete("{id:Guid}")]
    [Authorize]
    public async Task<IActionResult> DeleteArtist(Guid id)
    {
        try
        {
            await _mediator.Send(new DeleteArtistCommand(id));
            return NoContent();
        }
        catch (ArtistNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}