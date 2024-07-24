using IdentityServer.Domain;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IdentityServer.Application.Commands.Register;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMediator _mediator;
        public IConfiguration Configuration { get; }

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration, IMediator mediator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            Configuration = configuration;
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new RegisterCommand { RegisterRequest = model }, cancellationToken);
            if (response.Message.Contains("successfully"))
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new LoginCommand { LoginRequest = model }, cancellationToken);
            if (response.Token == "Invalid login attempt")
                return Unauthorized(response);
            else
                return Ok(response);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(CancellationToken cancellationToken)
        {
            var responce = await _mediator.Send(new LogoutCommand(), cancellationToken);
            if (responce.Message.Contains("successfully"))
                return Ok(responce.Message);
            else
                return BadRequest(responce);
        }
    }
}
