using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;

namespace Library.Application.Libraries.Commands.Book.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly ILibraryDbContext _libraryDbContext;

        public DeleteBookCommandHandler(ILibraryDbContext libraryDbContext) =>
            _libraryDbContext = libraryDbContext;

        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            Domain.Book? entity = await _libraryDbContext.Books
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            _libraryDbContext.Books.Remove(entity);
            await _libraryDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
