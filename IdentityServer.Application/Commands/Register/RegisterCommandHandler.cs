using IdentityServer.Application.DTO.Register;
using IdentityServer.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Application.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                UserName = request.RegisterRequest.UserName,
                Email = request.RegisterRequest.Email,
                FirstName = request.RegisterRequest.FirstName,
                Surname = request.RegisterRequest.Surname,
            };

            var result = await _userManager.CreateAsync(user, request.RegisterRequest.Password);
            if (!result.Succeeded)
                return new RegisterResponse { Message = string.Join(", ", result.Errors.Select(e => e.Description)) };

            return new RegisterResponse { Message = "User registered successfully" };
        }
    }
}
