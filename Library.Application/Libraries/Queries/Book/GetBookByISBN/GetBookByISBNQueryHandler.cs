using AutoMapper;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Application.Libraries.Queries.Book.DTO;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Libraries.Queries.Book.GetBookByISBN
{
    public class GetBookByISBNQueryHandler : IRequestHandler<GetBookByISBNQuery, BookResponseDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookByISBNQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookResponseDto> Handle(GetBookByISBNQuery request, 
            CancellationToken cancellationToken)
        {
            Domain.Entities.Book? entity = await _bookRepository.GetByIsbnAsync(request.ISBN, 
                cancellationToken); 

            if (entity is not { })
                throw new NotFoundException(nameof(Domain.Entities.Book), request.ISBN);

            return _mapper.Map<BookResponseDto>(entity);
        }
    }
}
