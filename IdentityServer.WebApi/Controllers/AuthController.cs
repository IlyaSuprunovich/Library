using IdentityServer.Domain;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IdentityServer.Application.Commands.Register;
using IdentityServer.Application.DTO.Register;
using IdentityServer.Application.DTO.Login;
using IdentityServer.Application.Commands.Login;
using IdentityServer.Application.Commands.Logout;

namespace IdentityServer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new RegisterCommand { RegisterRequest = model }, cancellationToken);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new LoginCommand { LoginRequest = model }, cancellationToken);
            return Ok(response);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(CancellationToken cancellationToken)
        {
            var responce = await _mediator.Send(new LogoutCommand(), cancellationToken);
            return Ok(responce.Message);
        }
    }
}
