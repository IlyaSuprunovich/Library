using Library.Application.Common.Exceptions;
using Library.Domain.Interfaces;
using MediatR;

namespace Library.Application.Libraries.Commands.Author.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
    {
        private readonly IAuthorRepository _authorRepository;

        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
            

        public async Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Author? entity = await _authorRepository.GetByIdAsync(request.Id, 
                cancellationToken);

            if (entity is not { })
                throw new NotFoundException(nameof(Domain.Entities.Author), request.Id);
            
            _authorRepository.Delete(entity);
            await _authorRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
