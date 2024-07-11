using AutoMapper;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Libraries.Queries.Author.GetAuthorDetails
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorVm>
    {
        private readonly ILibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public GetAuthorByIdQueryHandler(ILibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public async Task<AuthorVm> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Author? entity = await _libraryDbContext.Authors
                .FirstOrDefaultAsync(author =>
                author.Id == request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }

            return _mapper.Map<AuthorVm>(entity);
        }
    }
}
