using IdentityServer.Application.DTO.Logout;
using IdentityServer.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Application.Commands.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, LogoutResponse>
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LogoutCommandHandler(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<LogoutResponse> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
            return new LogoutResponse { Message = "User logged out successfully" };
        }

    }
}
