using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Repositories
{
    public class LibraryUserRepository : ILibraryUserRepository
    {
        private readonly ILibraryDbContext _libraryDbContext;

        public LibraryUserRepository(ILibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public async Task AddAsync(LibraryUser entity, CancellationToken cancellationToken)
        {
            await _libraryDbContext.LibraryUsers.AddAsync(entity, cancellationToken);
        }

        public void Delete(LibraryUser entity) => _libraryDbContext.LibraryUsers.Remove(entity);

        public async Task<IList<Book>> GetBooksAsync(Guid id, CancellationToken cancellationToken)
        {
            List<Book>? takenBooks = await _libraryDbContext.Books
                .AsNoTracking()
                .Include(b => b.Author)
                .Include(b => b.Image)
                .Include(b => b.LibraryUser)
                .Where(b => b.LibraryUserId == id)
                .ToListAsync(cancellationToken);

            if (takenBooks is not { })
            {
                throw new NotFoundException(nameof(Author), id);
            }

            return takenBooks;
        }

        public async Task<LibraryUser> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            LibraryUser? user = await _libraryDbContext.LibraryUsers.FirstOrDefaultAsync(u =>
                u.Id == id, cancellationToken);

            if (user is not { })
                throw new NotFoundException(nameof(LibraryUser), id);

            return user;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _libraryDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(LibraryUser entity, CancellationToken cancellationToken)
        {
            if (await _libraryDbContext.LibraryUsers.AsNoTracking().AnyAsync(l => l.Id == entity.Id))
                _libraryDbContext.LibraryUsers.Update(entity);
        }
    }
}
