using Library.Application.Commands.UpdateBook;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly ILibraryDbContext _libraryDbContext;

        public UpdateAuthorCommandHandler(ILibraryDbContext libraryDbContext) =>
            _libraryDbContext = libraryDbContext;

        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            Author? entity = await _libraryDbContext.Authors.FirstOrDefaultAsync(author =>
                author.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }

            entity.Name = request.Name;
            entity.Surname = request.Surname;
            entity.DateOfBirth = request.DateOfBirth;
            entity.Country = request.Country;
            entity.Books = request.Books;

            await _libraryDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

