using IdentityServer.Application.DTO.Register;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Application.Commands.Register
{
    public class RegisterCommand : IRequest<RegisterResponse>
    {
        public RegisterRequest RegisterRequest { get; set; }
    }
}
