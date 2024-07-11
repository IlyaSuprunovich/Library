using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Libraries.Queries.Book.GetBookDetails
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookVm>
    {
        private readonly ILibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(ILibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public async Task<BookVm> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            BookVm? entity = await _libraryDbContext.Books
                .ProjectTo<BookVm>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(book =>
                book.Id == request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            return _mapper.Map<BookVm>(entity);
        }
    }
}
