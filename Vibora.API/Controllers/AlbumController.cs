using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vibora.Application.Albums.Commands;
using Vibora.Application.Albums.Queries;
using Vibora.Domain.Exceptions;

namespace Vibora.API.Controllers;

[ApiController]
[Route("api/controller")]
public class AlbumController : ControllerBase
{
    private readonly ISender _mediator;

    public AlbumController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllAlbum()
    {
        var artists = await _mediator.Send(new GetAllAlbumQuery());
        return Ok(artists);
    }

    [HttpGet("{id:Guid}")]
    [Authorize]
    public async Task<IActionResult> GetAlbumById(Guid id)
    {
        try
        {
            var query = new GetAlbumByIdQuery(id);
            var album = await _mediator.Send(query);
            return Ok(album);
        }
        catch (AlbumNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateArtist([FromBody] CreateAlbumCommand command)
    {
        try
        {
            var artistId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAlbumById), new { id = artistId }, new { id = artistId });
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
            await _mediator.Send(new DeleteAlbumCommand(id));
            return NoContent();
        }
        catch (AlbumNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}

