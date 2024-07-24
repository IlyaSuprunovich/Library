using IdentityServer.Application.DTO.Login;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Application.Commands.Login
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public LoginRequest LoginRequest { get; set; }
    }
}
