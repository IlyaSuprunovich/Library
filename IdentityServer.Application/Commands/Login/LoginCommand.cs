using IdentityServer.Application.DTO.Login;
using MediatR;

namespace IdentityServer.Application.Commands.Login
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public LoginRequest LoginRequest { get; set; }
    }
}
