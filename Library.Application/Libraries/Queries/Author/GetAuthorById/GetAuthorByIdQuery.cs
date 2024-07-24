using Library.Application.Libraries.Queries.Author.DTO;
using MediatR;

namespace Library.Application.Libraries.Queries.Author.GetAuthorDetails
{
    public class GetAuthorByIdQuery : IRequest<AuthorResponseDto>
    {
        public Guid Id { get; set; }
    }
}
