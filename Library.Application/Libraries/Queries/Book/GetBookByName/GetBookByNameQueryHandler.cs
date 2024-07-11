using AutoMapper;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Libraries.Queries.Book.GetBookByName
{
    public class GetBookByNameQueryHandler : IRequestHandler<GetBookByNameQuery, BookByNameLookupDto>
    {
        private readonly ILibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public GetBookByNameQueryHandler(ILibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public async Task<BookByNameLookupDto> Handle(GetBookByNameQuery request, CancellationToken cancellationToken)
        {
            Domain.Book? entity = await _libraryDbContext.Books
                .Include(book => book.Author)
                .Include(book => book.Image)
                .FirstOrDefaultAsync(book =>
                    book.Name == request.Name, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Name);
            }

            return _mapper.Map<BookByNameLookupDto>(entity);
        }
    }
}
