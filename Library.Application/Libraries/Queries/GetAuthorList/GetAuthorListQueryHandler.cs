using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using Library.Application.Libraries.Queries.GetBookList;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.GetAuthorList
{
    public class GetAuthorListQueryHandler : IRequestHandler<GetAuthorListQuery, AuthorListVm>
    {
        private readonly ILibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public GetAuthorListQueryHandler(ILibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public async Task<AuthorListVm> Handle(GetAuthorListQuery request, CancellationToken cancellationToken)
        {
            var booksQuery = await _libraryDbContext.Authors
                .Where(author => author.Id == request.Id)
                .ProjectTo<AuthorLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new AuthorListVm { Authors = booksQuery };
        }
    }
}
