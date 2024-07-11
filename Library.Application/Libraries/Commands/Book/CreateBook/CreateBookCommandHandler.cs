using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Libraries.Commands.Book.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly ILibraryDbContext _libraryDbContext;

        public CreateBookCommandHandler(ILibraryDbContext libraryDbContext) =>
            _libraryDbContext = libraryDbContext;

        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            Domain.Author? author = request.Author;
            if (_libraryDbContext.Authors.Any(a => a.Id == request.AuthorId))
            {
                author = await _libraryDbContext.Authors.FindAsync(new object[] 
                    { request.AuthorId }, cancellationToken);
            }

            Domain.Book? book;

            if (_libraryDbContext.Books.Any(b => b.ISBN == request.ISBN && 
                b.Name == request.Name && b.Author == request.Author))
            {
                book = await _libraryDbContext.Books.FirstOrDefaultAsync(b => 
                    b.ISBN == request.ISBN, cancellationToken);
                book.CountBook += request.CountBook;
            }
            else
            {
                book = new Domain.Book
                {
                    ISBN = request.ISBN,
                    Name = request.Name,
                    Genre = request.Genre,
                    Description = request.Description,
                    Author = author,
                    AuthorId = request.AuthorId,
                    CountBook = request.CountBook,
                    ImageId = (Guid)request.ImageId
                };
                await _libraryDbContext.Books.AddAsync(book, cancellationToken);
                await _libraryDbContext.SaveChangesAsync(cancellationToken);
            }

            if (request.ImageId != Guid.Empty)
            {
                Domain.Image? image = await _libraryDbContext.Images.FindAsync(new object[] 
                    { request.ImageId }, cancellationToken);
                if (image != null)
                {
                    image.BookId = book.Id;
                    _libraryDbContext.Images.Update(image);
                }
            }

            await _libraryDbContext.SaveChangesAsync(cancellationToken);

            return book.Id;
        }
    }


}
