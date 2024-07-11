using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Libraries.Queries.Author.GetAuthorList
{
    public class GetAuthorListQueryHandler : IRequestHandler<GetAuthorListQuery, AuthorListVm>
    {
        private readonly ILibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public GetAuthorListQueryHandler(ILibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public async Task<AuthorListVm> Handle(GetAuthorListQuery request, CancellationToken cancellationToken)
        {
            List<AuthorLookupDto> booksQuery = await _libraryDbContext.Authors
                .ProjectTo<AuthorLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new AuthorListVm { Authors = booksQuery };
        }
    }
}
