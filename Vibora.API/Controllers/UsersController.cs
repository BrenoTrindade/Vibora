using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vibora.Application.Users.Commands;
using Vibora.Application.Users.Queries;
using Vibora.Domain.Entities;
using Vibora.Domain.Exceptions;

namespace Vibora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISender _mediator;

        public UsersController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            var userId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetUserById), new { id = userId }, new { id = userId });
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                var query = new GetUserByIdQuery(id);
                var user = await _mediator.Send(query);

                return Ok(user);

            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            
        }
    }
}