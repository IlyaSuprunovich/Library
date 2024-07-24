using AutoMapper;
using Library.Application.Common.Exceptions;
using Library.Application.Libraries.Queries.Book.DTO;
using Library.Domain.Interfaces;
using MediatR;

namespace Library.Application.Libraries.Queries.Book.GetBookByName
{
    public class GetBookByNameQueryHandler : IRequestHandler<GetBookByNameQuery, BookResponseDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookByNameQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookResponseDto> Handle(GetBookByNameQuery request, 
            CancellationToken cancellationToken)
        {
            Domain.Entities.Book? entity = await _bookRepository.GetByNameAsync(request.Name, 
                cancellationToken); 

            if (entity is not { })
                throw new NotFoundException(nameof(Book), request.Name);

            return _mapper.Map<BookResponseDto>(entity);
        }
    }
}
