using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Application.Libraries.Commands.Book.UpdateBook;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                book.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            entity.IsBookInLibrary = false;
            entity.TimeOfTake = DateTime.Now;
            entity.TimeOfReturn = DateTime.Now.AddDays(7);
            entity.NumberReaderTicket = request.NumberReaderTicket;

            await _libraryDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
