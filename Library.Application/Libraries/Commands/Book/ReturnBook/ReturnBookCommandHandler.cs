using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Application.Libraries.Commands.Book.TakeBook;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            entity.IsBookInLibrary = true;
            entity.TimeOfTake = null;
            entity.TimeOfReturn = null;
            entity.NumberReaderTicket = null;

            await _libraryDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
