using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Domain
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}
