using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Interfaces
{
    public interface ILibraryDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Author> Authors { get; set;}
        DbSet<Image> Images { get; set; }
        DbSet<LibraryUser> LibraryUsers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
