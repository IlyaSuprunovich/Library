using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using Library.Application.Libraries.Queries.Book.GetBookList;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.Author.GetAllAuthorBooks
{
    public class GetAllAuthorBookQueryHandler : IRequestHandler<GetAllAuthorBookQuery, AllAuthorBookVm>
    {
        private readonly ILibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public GetAllAuthorBookQueryHandler(ILibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public async Task<AllAuthorBookVm> Handle(GetAllAuthorBookQuery request, CancellationToken cancellationToken)
        {
            var booksQuery = await _libraryDbContext.Books
                //.Where(book => book.AuthorId == request.)
                .ProjectTo<AllAuthorBookLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new AllAuthorBookVm { Books = booksQuery };
        }
    }
}
