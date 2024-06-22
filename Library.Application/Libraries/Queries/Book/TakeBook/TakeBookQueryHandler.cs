using AutoMapper;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Application.Libraries.Queries.Book.GetBookDetails;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.Book.TakeBook
{
    public class TakeBookQueryHandler : IRequestHandler<TakeBookQuery, TakeBookVm>
    {
        private readonly ILibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public TakeBookQueryHandler(ILibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public async Task<TakeBookVm> Handle(TakeBookQuery request, CancellationToken cancellationToken)
        {
            var entity = await _libraryDbContext.Books
                .FirstOrDefaultAsync(book =>
                book.Id == request.Id);

            if (entity == null /*|| entity.AuthorId != request.AuthorId*/)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            return _mapper.Map<TakeBookVm>(entity);
        }
    }
}
