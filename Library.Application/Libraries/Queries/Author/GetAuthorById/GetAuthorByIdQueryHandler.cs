using AutoMapper;
using Library.Application.Libraries.Queries.Author.DTO;
using Library.Domain.Interfaces;
using MediatR;

namespace Library.Application.Libraries.Queries.Author.GetAuthorDetails
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorResponseDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorResponseDto> Handle(GetAuthorByIdQuery request, 
            CancellationToken cancellationToken)
        {
            Domain.Entities.Author? entity = await _authorRepository.GetByIdAsync(request.Id, 
                cancellationToken);

            return _mapper.Map<AuthorResponseDto>(entity);
        }
    }
}
