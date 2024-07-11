using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Libraries.Queries.LibraryUser.GetTakenBooks
{
    public class GetTakenBooksListQueryHandler : IRequestHandler<GetTakenBooksListQuery, TakenBooksListVm>
    {
        private readonly ILibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public GetTakenBooksListQueryHandler(ILibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public async Task<TakenBooksListVm> Handle(GetTakenBooksListQuery request, CancellationToken cancellationToken)
        {
            List<TakenBooksLookupDto> booksQuery = await _libraryDbContext.Books
                .Where(book => book.LibraryUserId == request.Id)
                .ProjectTo<TakenBooksLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new TakenBooksListVm { TakenBooks = booksQuery };
        }
    }
}
