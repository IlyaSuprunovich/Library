using Library.Application.Commands.CreateBook;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Guid>
    {
        private readonly ILibraryDbContext _libraryDbContext;

        public CreateAuthorCommandHandler(ILibraryDbContext libraryDbContext) =>
            _libraryDbContext = libraryDbContext;

        public async Task<Guid> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {

            Author author = new()
            {
                Name = request.Name,
                Surname = request.Surname,
                DateOfBirth = request.DateOfBirth,
                Country = request.Country,
                Books = request.Books
            };

            await _libraryDbContext.Authors.AddAsync(author, cancellationToken);
            await _libraryDbContext.SaveChangesAsync(cancellationToken);

            return author.Id;
        }
    }
}
