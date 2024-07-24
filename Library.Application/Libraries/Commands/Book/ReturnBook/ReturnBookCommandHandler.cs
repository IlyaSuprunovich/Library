using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Libraries.Commands.Book.ReturnBook
{
    public class ReturnBookCommandHandler : IRequestHandler<ReturnBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public ReturnBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        } 

        public async Task Handle(ReturnBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.ReturnAsync(request.Id, request.LibraryUserId, cancellationToken);
            await _bookRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
