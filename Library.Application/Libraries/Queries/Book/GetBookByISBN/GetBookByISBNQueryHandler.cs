using AutoMapper;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Application.Libraries.Queries;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var entity = await _libraryDbContext.Books
                .FirstOrDefaultAsync(book =>
                book.ISBN == request.ISBN);

            if (entity == null /*|| entity.AuthorId != request.AuthorId*/)
            {
                throw new NotFoundException(nameof(Book), request.ISBN);
            }

            return _mapper.Map<BookByISBNVm>(entity);
        }
    }
}
