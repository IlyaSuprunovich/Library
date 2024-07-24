using Library.Application.Common.Exceptions;
using Library.Domain.Interfaces;
using MediatR;

namespace Library.Application.Libraries.Commands.Author.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Guid>
    {
        private readonly IAuthorRepository _authorRepository;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
           

        public async Task<Guid> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Author author = new()
            {
                Id = Guid.NewGuid(),
                Name = request.Author.Name,
                Surname = request.Author.Surname,
                DateOfBirth = request.Author.DateOfBirth,
                Country = request.Author.Country,
            };

            if(await _authorRepository.HasDbAuthor(author, cancellationToken))
                throw new AlreadyExists(nameof(Domain.Entities.Author), author.Id);
            else
            {
                await _authorRepository.AddAsync(author, cancellationToken);
                await _authorRepository.SaveChangesAsync(cancellationToken);
                return author.Id;
            } 
        }
    }
}
