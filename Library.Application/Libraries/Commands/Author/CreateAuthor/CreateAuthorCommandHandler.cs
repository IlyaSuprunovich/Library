using AutoMapper;
using Library.Application.Common.Exceptions;
using Library.Domain.Interfaces;
using MediatR;

namespace Library.Application.Libraries.Commands.Author.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Guid>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
           

        public async Task<Guid> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Author author = _mapper.Map<Domain.Entities.Author>(request.Author);
            author.Id = Guid.NewGuid();

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
