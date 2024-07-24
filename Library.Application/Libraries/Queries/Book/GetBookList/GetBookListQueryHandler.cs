using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Libraries.Queries.Book.DTO;
using Library.Domain.Interfaces;
using MediatR;

namespace Library.Application.Libraries.Queries.Book.GetBookList
{
    public class GetBookListQueryHandler : IRequestHandler<GetBookListQuery, 
        PagedResponse<BookResponseDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookListQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<BookResponseDto>> Handle(GetBookListQuery request, 
            CancellationToken cancellationToken)
        {

            IEnumerable<Domain.Entities.Book> books = await _bookRepository.GetListAsync(cancellationToken);

            IEnumerable<Domain.Entities.Book> filteredBooks = books
                .Where(b => (request.Genre == null || b.Genre == request.Genre) &&
                            (request.Name == null || b.Name.Contains(request.Name)));

            IQueryable<BookResponseDto> query = filteredBooks
                .AsQueryable()
                .ProjectTo<BookResponseDto>(_mapper.ConfigurationProvider);

            int totalRecords = query.Count();

            if (request.PageNumber != null && request.PageSize != null)
            {
                query = query
                    .Skip((request.PageNumber.Value - 1) * request.PageSize.Value)
                    .Take(request.PageSize.Value);
            }

            List<BookResponseDto> booksList = query.ToList();

            return new PagedResponse<BookResponseDto>(booksList, request.PageNumber ?? 1, 
                request.PageSize ?? totalRecords, totalRecords);
        }
    }
}
