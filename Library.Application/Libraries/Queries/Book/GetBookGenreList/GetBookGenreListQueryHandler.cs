using Library.Application.Libraries.Queries.Book.DTO;
using Library.Domain.Interfaces;
using MediatR;

namespace Library.Application.Libraries.Queries.Book.GetBookGenreList
{
    public class GetGenresListQueryHandler : IRequestHandler<GetBookGenreListQuery, 
        BookGenreListResponseDto>
    {
        private readonly IBookRepository _bookRepository;

        public GetGenresListQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookGenreListResponseDto> Handle(GetBookGenreListQuery request, 
            CancellationToken cancellationToken)
        {
            IList<string> genres = await _bookRepository.GetGenreList(cancellationToken);

            BookGenreListResponseDto result = new() 
            {
                Genres = genres,
            };

            return result;
        }
    }
}
