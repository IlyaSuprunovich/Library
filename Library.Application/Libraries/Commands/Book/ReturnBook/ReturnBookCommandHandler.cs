using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Libraries.Commands.Book.ReturnBook
{
    public class ReturnBookCommandHandler : IRequestHandler<ReturnBookCommand>
    {
        private readonly ILibraryDbContext _libraryDbContext;

        public ReturnBookCommandHandler(ILibraryDbContext libraryDbContext) =>
            _libraryDbContext = libraryDbContext;

        public async Task Handle(ReturnBookCommand request, CancellationToken cancellationToken)
        {
            Domain.Book? entity = await _libraryDbContext.Books.FirstOrDefaultAsync(book =>
                book.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            LibraryUser? user = await _libraryDbContext.LibraryUsers.FirstOrDefaultAsync(user =>
                user.Id == request.LibraryUserId);

            if (user is not { })
            {
                throw new NotFoundException(nameof(LibraryUser), request.LibraryUserId);
            }

            user?.TakenBooks?.Remove(entity);
            
            entity.TimeOfTake = null;
            entity.TimeOfReturn = null;
            entity.LibraryUser = null;
            entity.LibraryUserId = null;
            entity.CountBook += 1;
            
            if(entity.CountBook > 0)
                entity.IsBookInLibrary = true;

            await _libraryDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
