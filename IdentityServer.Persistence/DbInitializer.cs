using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
