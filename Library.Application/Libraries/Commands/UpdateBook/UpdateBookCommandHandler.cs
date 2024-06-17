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

namespace Library.Application.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly ILibraryDbContext _libraryDbContext;

        public UpdateBookCommandHandler(ILibraryDbContext libraryDbContext) =>
            _libraryDbContext = libraryDbContext;

        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            Book? entity = await _libraryDbContext.Books.FirstOrDefaultAsync(book =>
                book.Id == request.Id, cancellationToken);

            if (entity == null || entity.AuthorId != request.AuthorId)
            {
                throw new NotFoundException(nameof(Book), request.Id); 
            }

            entity.ISBN = request.ISBN;
            entity.Name = request.Name;
            entity.Genre = request.Genre;
            entity.Description = request.Description;
            entity.Author = request.Author;
            entity.AuthorId = request.AuthorId;

            await _libraryDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
