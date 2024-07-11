using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Library.Domain;

namespace Library.Application.Libraries.Commands.Book.TakeBook
{
    public class TakeBookCommandHandler : IRequestHandler<TakeBookCommand>
    {
        private readonly ILibraryDbContext _libraryDbContext;

        public TakeBookCommandHandler(ILibraryDbContext libraryDbContext) =>
            _libraryDbContext = libraryDbContext;

        public async Task Handle(TakeBookCommand request, CancellationToken cancellationToken)
        {
            Domain.Book? entity = await _libraryDbContext.Books.FirstOrDefaultAsync(book =>
                book.Id == request.Id && book.IsBookInLibrary == true, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            LibraryUser? user = await _libraryDbContext.LibraryUsers.FirstOrDefaultAsync(user =>
                user.Id == request.LibraryUserId);

            if (user == null)
            {
                user = new LibraryUser { Id = request.LibraryUserId };
                await _libraryDbContext.LibraryUsers.AddAsync(user, cancellationToken);
                await _libraryDbContext.SaveChangesAsync(cancellationToken);
            }

            if (user.TakenBooks == null)
            {
                user.TakenBooks = new List<Domain.Book> { entity };
            }
            else
            {
                user.TakenBooks.Add(entity);
            }

            
            entity.TimeOfTake = DateTime.Now;
            entity.TimeOfReturn = DateTime.Now.AddDays(7);
            entity.LibraryUser = user;
            entity.LibraryUserId = user.Id;
            entity.CountBook -= 1;

            if(entity.CountBook == 0)
            {
                entity.IsBookInLibrary = false;
            }

            await _libraryDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
