using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Vibora.Application.Users.Commands; // Adicione este

namespace Vibora.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly ISender _mediator;

    public AuthController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("google")]
    public IActionResult GoogleLogin()
    {
        var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleCallback") };
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    [HttpGet("google-callback")]
    public async Task<IActionResult> GoogleCallback()
    {
        var authResult = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);

        if (!authResult.Succeeded)
        {
            return BadRequest("Falha na autenticação com o Google.");
        }

        var userEmail = authResult.Principal.FindFirstValue(ClaimTypes.Email);
        var userName = authResult.Principal.FindFirstValue(ClaimTypes.Name);
        var googleId = authResult.Principal.FindFirstValue(ClaimTypes.NameIdentifier);

        var command = new AuthenticateWithGoogleCommand
        {
            Email = userEmail,
            Name = userName,
            GoogleId = googleId
        };

        var viboraAuthResponse = await _mediator.Send(command);

        return Ok(viboraAuthResponse);
    }
}