using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence
{
    public class LibraryContextFactory : IDesignTimeDbContextFactory<LibraryDbContext>
    {
        public LibraryDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryDbContext>();

            ConfigurationBuilder builder = new();
            builder.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), @"..\Library.WebApi"));
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            string connectionString = config.GetConnectionString("DbConnection");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new LibraryDbContext(optionsBuilder.Options);
        }
    }
}
