using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Common.Exceptions;
using Library.Application.Libraries.Queries.Author.DTO;
using Library.Application.Libraries.Queries.Book.DTO;
using Library.Domain.Interfaces;
using MediatR;

namespace Library.Application.Libraries.Queries.Author.GetAllAuthorBooks
{
    public class GetAllAuthorBookQueryHandler : IRequestHandler<GetAllAuthorBookQuery, 
        AllAuthorBookResponseDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAllAuthorBookQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AllAuthorBookResponseDto> Handle(GetAllAuthorBookQuery request, 
            CancellationToken cancellationToken)
        {
            IQueryable<Domain.Entities.Book> books = await _authorRepository.GetBooksAsync(
                request.AuthorId, cancellationToken);

            if (books is not { })
                throw new NotFoundException(nameof(Domain.Entities.Book), request.AuthorId);

            List<BookResponseDto> booksQuery = books
                .ProjectTo<BookResponseDto>(_mapper.ConfigurationProvider)
                .ToList();
            return new AllAuthorBookResponseDto { Books = booksQuery };
        }
    }
}
