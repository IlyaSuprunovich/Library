using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Libraries.Commands.Author.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Guid>
    {
        private readonly ILibraryDbContext _libraryDbContext;

        public CreateAuthorCommandHandler(ILibraryDbContext libraryDbContext) =>
            _libraryDbContext = libraryDbContext;

        public async Task<Guid> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            Domain.Author? author = await _libraryDbContext.Authors.FirstOrDefaultAsync(author =>
                author.Name == request.Name &&
                author.Surname == request.Surname &&
                author.Country == request.Country &&
                author.DateOfBirth == request.DateOfBirth);

            if(author != null)
                return author.Id;


            Domain.Author newAuthor = new()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Surname = request.Surname,
                DateOfBirth = request.DateOfBirth,
                Country = request.Country,
                Books = request.Books
            };

            await _libraryDbContext.Authors.AddAsync(newAuthor, cancellationToken);
            await _libraryDbContext.SaveChangesAsync(cancellationToken);

            return newAuthor.Id;
        }
    }
}
