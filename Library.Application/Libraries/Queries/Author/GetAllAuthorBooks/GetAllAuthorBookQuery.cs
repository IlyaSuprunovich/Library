using Library.Application.Libraries.Queries.Author.DTO;
using MediatR;

namespace Library.Application.Libraries.Queries.Author.GetAllAuthorBooks
{
    public class GetAllAuthorBookQuery : IRequest<AllAuthorBookResponseDto>
    {
        public Guid AuthorId { get; set; }
    }
}
