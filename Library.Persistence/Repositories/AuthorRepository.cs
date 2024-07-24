using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Application.Libraries.Commands.Author.CreateAuthor;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ILibraryDbContext _libraryDbContext;

        public AuthorRepository(ILibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public async Task AddAsync(Author entity, CancellationToken cancellationToken)
        {
            await _libraryDbContext.Authors.AddAsync(entity, cancellationToken);
        }

        public void Delete(Author entity) => _libraryDbContext.Authors.Remove(entity);

        public async Task<IQueryable<Book>> GetBooksAsync(Guid id, CancellationToken cancellationToken)
        {
            List<Book> books = await _libraryDbContext.Books
                .AsNoTracking()
                .Where(b => b.AuthorId == id)
                .ToListAsync(cancellationToken);

            if(books is not { })
                throw new NotFoundException(nameof(Author), id);

            return books.AsQueryable();
        }

        public async Task<Author> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            Author? author = await _libraryDbContext.Authors.FirstOrDefaultAsync(b =>
                b.Id == id, cancellationToken);

            if (author is not { })
                throw new NotFoundException(nameof(Author), id);

            return author;
        }

        public IQueryable<Author> GetList(CancellationToken cancellationToken)
        {
            return _libraryDbContext.Authors.AsNoTracking().AsQueryable();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _libraryDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Author entity, CancellationToken cancellationToken)
        {
            Author? author = await _libraryDbContext.Authors.FirstOrDefaultAsync(b =>
                b.Id == entity.Id, cancellationToken);

            if (author is not { })
                throw new NotFoundException(nameof(Author), entity.Id);

            author.Name = entity.Name;
            author.Surname = entity.Surname;
            author.Country = entity.Country;
            author.DateOfBirth = entity.DateOfBirth;
            author.Books = entity.Books;
        }

        public async Task<bool> HasDbAuthor(Author entity, 
            CancellationToken cancellationToken)
        {
            Author? author = await _libraryDbContext.Authors.AsNoTracking().FirstOrDefaultAsync(author =>
                author.Name == entity.Name &&
                author.Surname == entity.Surname &&
                author.Country == entity.Country &&
                author.DateOfBirth == entity.DateOfBirth, cancellationToken);

            if (author is not { })
                return false;
            else
                return true;
        }
    }
}
