using IdentityServer.Application.DTO.Login;
using IdentityServer.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Application.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public LoginCommandHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.LoginRequest.UserName, request.LoginRequest.Password, false, false);
            if (!result.Succeeded)
                return new LoginResponse { Token = "Invalid login attempt" };

            var user = await _userManager.FindByNameAsync(request.LoginRequest.UserName);

            if (user == null)
                return new LoginResponse { Token = "Invalid login attempt" };

            var token = GenerateJwtToken(user);
            return new LoginResponse { Token = token };
        }

        private string GenerateJwtToken(AppUser user)
        {
            var userClaims = _userManager.GetClaimsAsync(user).Result;
            IList<string> userRoles = _userManager.GetRolesAsync(user).Result;

            if (userRoles.Count < 1)
                userRoles.Add("User");

            var roleClaims = userRoles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("scope", "book_api"),
            }
            .Union(userClaims)
            .Union(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
