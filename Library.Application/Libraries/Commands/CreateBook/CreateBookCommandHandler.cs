using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly ILibraryDbContext _libraryDbContext;

        public CreateBookCommandHandler(ILibraryDbContext libraryDbContext) =>
            _libraryDbContext = libraryDbContext;

        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            
            Book book = new()
            {
                ISBN = request.ISBN,
                Name = request.Name,
                Genre = request.Genre,
                Description = request.Description,
                Author = request.Author,
                AuthorId = request.AuthorId,
            };

            await _libraryDbContext.Books.AddAsync(book, cancellationToken);
            await _libraryDbContext.SaveChangesAsync(cancellationToken);

            return book.Id;
        }
    }
}
