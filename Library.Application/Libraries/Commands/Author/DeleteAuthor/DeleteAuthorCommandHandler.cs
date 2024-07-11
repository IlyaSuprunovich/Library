using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;

namespace Library.Application.Libraries.Commands.Author.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
    {
        private readonly ILibraryDbContext _libraryDbContext;

        public DeleteAuthorCommandHandler(ILibraryDbContext libraryDbContext) =>
            _libraryDbContext = libraryDbContext;

        public async Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            Domain.Author? entity = await _libraryDbContext.Authors
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }

            _libraryDbContext.Authors.Remove(entity);
            await _libraryDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
