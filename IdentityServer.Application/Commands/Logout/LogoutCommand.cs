using IdentityServer.Application.DTO.Login;
using IdentityServer.Application.DTO.Logout;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Application.Commands.Logout
{
    public class LogoutCommand : IRequest<LogoutResponse>
    {

    }
}
