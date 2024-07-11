using AutoMapper;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Libraries.Queries.Book.GetBookByISBN
{
    public class GetBookByISBNQueryHandler : IRequestHandler<GetBookByISBNQuery, BookByISBNVm>
    {
        private readonly ILibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public GetBookByISBNQueryHandler(ILibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public async Task<BookByISBNVm> Handle(GetBookByISBNQuery request, CancellationToken cancellationToken)
        {
            Domain.Book? entity = await _libraryDbContext.Books
                .FirstOrDefaultAsync(book =>
                book.ISBN == request.ISBN);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.ISBN);
            }

            return _mapper.Map<BookByISBNVm>(entity);
        }
    }
}
