using IdentityServer.Application.DTO.Register;
using MediatR;

namespace IdentityServer.Application.Commands.Register
{
    public class RegisterCommand : IRequest<RegisterResponse>
    {
        public RegisterRequest RegisterRequest { get; set; }
    }
}
