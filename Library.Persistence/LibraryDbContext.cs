
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence
{
    public class LibraryDbContext : DbContext, ILibraryDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Image> Images { get; set; } 
        public DbSet<LibraryUser> LibraryUsers { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AuthorConfiguration());
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new ImageConfiguration());
            builder.ApplyConfiguration(new LibraryUserConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
