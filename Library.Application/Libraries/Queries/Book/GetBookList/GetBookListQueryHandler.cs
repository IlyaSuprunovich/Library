using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Libraries.Queries.Book.GetBookList
{
    public class GetBookListQueryHandler : IRequestHandler<GetBookListQuery, PagedResponse<BookLookupDto>>
    {
        private readonly ILibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public GetBookListQueryHandler(ILibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public async Task<PagedResponse<BookLookupDto>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<BookLookupDto> query = _libraryDbContext.Books
                .Where(b => (request.Genre == null || b.Genre == request.Genre) &&
                        (request.Name == null || b.Name.Contains(request.Name)))
                .ProjectTo<BookLookupDto>(_mapper.ConfigurationProvider);

            int totalRecords = await query.CountAsync(cancellationToken);

            if (request.PageNumber != null && request.PageSize != null)
            {
                query = query
                    .Skip((request.PageNumber.Value - 1) * request.PageSize.Value)
                    .Take(request.PageSize.Value);
            }

            List<BookLookupDto> books = await query.ToListAsync(cancellationToken);

            return new PagedResponse<BookLookupDto>(books, request.PageNumber ?? 1, 
                request.PageSize ?? totalRecords, totalRecords);
        }
    }
}
