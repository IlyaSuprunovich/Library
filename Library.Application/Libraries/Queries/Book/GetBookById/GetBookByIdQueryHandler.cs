using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Application.Libraries.Queries.Book.DTO;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Libraries.Queries.Book.GetBookDetails
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookResponseDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookResponseDto> Handle(GetBookByIdQuery request, 
            CancellationToken cancellationToken)
        {
            Domain.Entities.Book entity = await _bookRepository.GetByIdAsync(request.Id, 
                cancellationToken);

            if (entity is not { })
                throw new NotFoundException(nameof(Book), request.Id);

            return _mapper.Map<BookResponseDto>(entity);
        }
    }
}
