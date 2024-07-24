using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using Library.Application.Libraries.Queries.Author.DTO;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Libraries.Queries.Author.GetAuthorList
{
    public class GetAuthorListQueryHandler : IRequestHandler<GetAuthorListQuery, AuthorListResponseDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAuthorListQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorListResponseDto> Handle(GetAuthorListQuery request, 
            CancellationToken cancellationToken)
        {
            IQueryable<Domain.Entities.Author> authorsQuery = _authorRepository.GetList(cancellationToken);

            List<AuthorResponseDto> authors = await authorsQuery
                .ProjectTo<AuthorResponseDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new AuthorListResponseDto { Authors = authors };
        }
    }
}
