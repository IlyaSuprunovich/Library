using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Library.Domain.Entities;
using Library.Domain.Interfaces;

namespace Library.Application.Libraries.Commands.Book.TakeBook
{
    public class TakeBookCommandHandler : IRequestHandler<TakeBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public TakeBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        } 

        public async Task Handle(TakeBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.TakeAsync(request.Id, request.LibraryUserId, cancellationToken);
            await _bookRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
