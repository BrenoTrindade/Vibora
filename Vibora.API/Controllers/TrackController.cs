using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vibora.Application.Tracks.Commands;
using Vibora.Application.Tracks.Queries;
using Vibora.Domain.Entities;
using Vibora.Domain.Exceptions;

namespace Vibora.API.Controllers;

public class TrackController : ControllerBase
{
    private readonly ISender _mediator;

    public TrackController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> GetTrackById(Guid id)
    {
        try
        {
            var query = new GetTrackByIdQuery(id);

            var track = await _mediator.Send(query);

            return Ok(track);

        }
        catch (TrackNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost("Register")]
    [Authorize]
    public async Task<IActionResult> Register([FromBody] RegisterTrackCommand command)
    {
        try
        {
            var trackId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetTrackById), new { id = trackId }, new { id = trackId });
        }
        catch (Exception)
        {

            throw;
        }
    }
}

