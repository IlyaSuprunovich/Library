using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Libraries.Commands.Author.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IAuthorRepository _authorRepository;

        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
            
        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Author author = new()
            {
                Id = request.Author.Id,
                Name = request.Author.Name,
                Surname = request.Author.Surname,
                DateOfBirth = request.Author.DateOfBirth,
                Country = request.Author.Country,
                Books = request.Author.Books
            };

            await _authorRepository.UpdateAsync(author, cancellationToken);
            await _authorRepository.SaveChangesAsync(cancellationToken);
        }
    }
}

