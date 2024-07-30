using AutoMapper;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ILibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public BookRepository(ILibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public async Task AddAsync(Book entity, CancellationToken cancellationToken)
        {
            await _libraryDbContext.Books.AddAsync(entity, cancellationToken);
        }

        public void Delete(Book entity) => _libraryDbContext.Books.Remove(entity);

        public async Task<Book> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            Book? book = await _libraryDbContext.Books
                .Include(b => b.Author)
                .Include(b => b.Image)
                .Include(b => b.LibraryUser)
                .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

            if (book is not { })
                throw new NotFoundException(nameof(Book), id);

            return book;
        }

        public async Task<Book> GetByIsbnAsync(string isbn, CancellationToken cancellationToken)
        {
            Book? book = await _libraryDbContext.Books
                .AsNoTracking()
                .Include(b => b.Author)
                .Include(b => b.Image)
                .Include(b => b.LibraryUser)
                .FirstOrDefaultAsync(b =>
                b.ISBN == isbn, cancellationToken);

            if (book is not { })
                throw new NotFoundException(nameof(Book), isbn);

            return book;
        }

        public async Task<Book> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            Book? book = await _libraryDbContext.Books
                .Include(b => b.Author)
                .Include(b => b.Image)
                .Include(b => b.LibraryUser)
                .FirstOrDefaultAsync(b =>
                b.Name == name, cancellationToken);

            return book;
        }

        public async Task<IList<string>> GetGenreList(CancellationToken cancellationToken)
        {
            List<string>? genres = await _libraryDbContext.Books
                .AsNoTracking()
                .Select(b => b.Genre)
                .Distinct()
                .ToListAsync(cancellationToken);

            return genres;
        }

        public async Task<IEnumerable<Book>> GetListAsync(CancellationToken cancellationToken)
        {
            return await _libraryDbContext.Books
                .AsNoTracking()
                .Include(b => b.Author)
                .Include(b => b.Image)
                .Include(b => b.LibraryUser)
                .ToArrayAsync(cancellationToken);
        }

        public async Task ReturnAsync(Guid bookId, Guid userId, CancellationToken cancellationToken)
        {
            Book? book = await _libraryDbContext.Books.FirstOrDefaultAsync(b =>
                b.Id == bookId, cancellationToken);

            if (book is not { })
                throw new NotFoundException(nameof(Book), bookId);

            LibraryUser? libraryUser = await _libraryDbContext.LibraryUsers.FirstOrDefaultAsync(u =>
                u.Id == userId, cancellationToken);

            if (libraryUser is not { })
                throw new NotFoundException(nameof(LibraryUser), userId);

            libraryUser?.TakenBooks?.Remove(book);

            Book returnedBook = new()
            {
                Id = book.Id,
                TimeOfTake = null,
                TimeOfReturn = null,
                LibraryUserId = null,
                IsBookInLibrary = true
            };

            if (_libraryDbContext.Books.Local.Any(b => b.Id == book.Id))
                _libraryDbContext.Books.Entry(book).State = EntityState.Detached;

            _mapper.Map(book, returnedBook);

            _libraryDbContext.Books.Attach(returnedBook);
            _libraryDbContext.Books.Entry(returnedBook).State = EntityState.Modified;

            await SaveChangesAsync(cancellationToken);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _libraryDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task TakeAsync(Guid bookId, Guid userId, CancellationToken cancellationToken)
        {
            Book? book = await _libraryDbContext.Books.AsNoTracking().FirstOrDefaultAsync(b =>
               b.Id == bookId, cancellationToken);

            if (book is not { })
                throw new NotFoundException(nameof(Book), bookId);

            LibraryUser? libraryUser = await _libraryDbContext.LibraryUsers.FirstOrDefaultAsync(u =>
                u.Id == userId, cancellationToken);

            if (libraryUser is not { })
            {
                libraryUser = new LibraryUser { Id = userId };
                await _libraryDbContext.LibraryUsers.AddAsync(libraryUser, cancellationToken);
                await _libraryDbContext.SaveChangesAsync(cancellationToken);
            }

            if (libraryUser.TakenBooks is not { })
                libraryUser.TakenBooks = new List<Book> { book };
            else
                libraryUser.TakenBooks.Add(book);

            Book takedBook = new()
            {
                Id = book.Id,
                TimeOfTake = DateTime.Now,
                TimeOfReturn = DateTime.Now.AddDays(7),
                LibraryUserId = libraryUser.Id,
                IsBookInLibrary = false,
            };

            if (_libraryDbContext.Books.Local.Any(b => b.Id == book.Id))
                _libraryDbContext.Books.Entry(book).State = EntityState.Detached;

            _mapper.Map(book, takedBook);

            _libraryDbContext.Books.Attach(takedBook);
            _libraryDbContext.Books.Entry(takedBook).State = EntityState.Modified;
        }

        public async Task UpdateAsync(Book entity, CancellationToken cancellationToken)
        {
            Book? book = await _libraryDbContext.Books.FirstOrDefaultAsync(b =>
                b.Id == entity.Id, cancellationToken);

            if (book is not { })
                throw new NotFoundException(nameof(Book), entity.Id);

            if (_libraryDbContext.Books.Local.Any(b => b.Id == book.Id))
                _libraryDbContext.Books.Entry(book).State = EntityState.Detached;

            _mapper.Map(entity, book);

            _libraryDbContext.Books.Attach(book);
            _libraryDbContext.Books.Entry(book).State = EntityState.Modified;
        }
    }
}
