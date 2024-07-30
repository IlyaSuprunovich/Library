using AutoMapper;
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
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
            
        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Author author = _mapper.Map<Domain.Entities.Author>(request.Author);

            await _authorRepository.UpdateAsync(author, cancellationToken);
            await _authorRepository.SaveChangesAsync(cancellationToken);
        }
    }
}

