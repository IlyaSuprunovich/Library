using Library.Application.Libraries.Queries.Author.DTO;
using MediatR;

namespace Library.Application.Libraries.Queries.Author.GetAuthorList
{
    public class GetAuthorListQuery : IRequest<AuthorListResponseDto>
    {
    }
}
