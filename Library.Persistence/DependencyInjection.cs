using Library.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, 
            IConfiguration configuration)
        {
            string? connectionStringLibrary = configuration.GetConnectionString("DbConnection");

            Console.WriteLine($"Library Connection String: {connectionStringLibrary}");


            services.AddDbContext<LibraryDbContext>(options =>
            {
                options.UseMySql(connectionStringLibrary, 
                    ServerVersion.AutoDetect(connectionStringLibrary));
            });

            services.AddScoped<ILibraryDbContext>(provider => provider.GetService<LibraryDbContext>());

            return services;
        }
    }
}
