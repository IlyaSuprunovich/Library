using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Libraries.Commands.Book.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly ILibraryDbContext _libraryDbContext;

        public UpdateBookCommandHandler(ILibraryDbContext libraryDbContext) =>
            _libraryDbContext = libraryDbContext;

        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            Domain.Book? entity = await _libraryDbContext.Books.FirstOrDefaultAsync(book =>
                book.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            entity.ISBN = request.ISBN;
            entity.Name = request.Name;
            entity.Genre = request.Genre;
            entity.Description = request.Description;
            entity.Author = request.Author;
            entity.AuthorId = request.AuthorId;
            entity.CountBook = request.CountBook;
            entity.Image = request.Image;
            entity.ImageId = request.ImageId;

            await _libraryDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
