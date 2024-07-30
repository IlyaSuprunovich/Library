using IdentityServer.Application.DTO.Logout;
using MediatR;

namespace IdentityServer.Application.Commands.Logout
{
    public class LogoutCommand : IRequest<LogoutResponse>
    {

    }
}
