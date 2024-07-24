using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using Library.Application.Libraries.Queries.Book.DTO;
using Library.Application.Libraries.Queries.Book.GetBookList;
using Library.Application.Libraries.Queries.LibraryUser.DTO;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Libraries.Queries.LibraryUser.GetTakenBooks
{
    public class GetTakenBooksListQueryHandler : IRequestHandler<GetTakenBooksListQuery, 
        TakenBooksListResponseDto>
    {
        private readonly ILibraryUserRepository _libraryUserRepository;
        private readonly IMapper _mapper;

        public GetTakenBooksListQueryHandler(ILibraryUserRepository libraryUserRepository, 
            IMapper mapper)
        {
            _libraryUserRepository = libraryUserRepository;
            _mapper = mapper;
        }

        public async Task<TakenBooksListResponseDto> Handle(GetTakenBooksListQuery request, 
            CancellationToken cancellationToken)
        {
            IList<Domain.Entities.Book> booksQuery = await _libraryUserRepository.GetBooksAsync(
                request.Id, cancellationToken);

            IQueryable<BookResponseDto> takenBooks = booksQuery
                .AsQueryable()
                .ProjectTo<BookResponseDto>(_mapper.ConfigurationProvider);

            return new TakenBooksListResponseDto { TakenBooks = takenBooks.ToList() };
        }
    }
}
