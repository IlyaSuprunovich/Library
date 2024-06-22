using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Commands.Book.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly ILibraryDbContext _libraryDbContext;

        public CreateBookCommandHandler(ILibraryDbContext libraryDbContext) =>
            _libraryDbContext = libraryDbContext;

        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var author = request.Author;
            if (_libraryDbContext.Authors.Any(a => a.Id == request.AuthorId) == true)
                author = await _libraryDbContext.Authors.FindAsync(new object[] { request.AuthorId },
                    cancellationToken);

            Domain.Book book = new()
            {
                ISBN = request.ISBN,
                Name = request.Name,
                Genre = request.Genre,
                Description = request.Description,
                Author = author,
                AuthorId = request.AuthorId,
            };

            await _libraryDbContext.Books.AddAsync(book, cancellationToken);
            await _libraryDbContext.SaveChangesAsync(cancellationToken);

            return book.Id;
        }
    }
}
