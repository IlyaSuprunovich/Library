using Library.Application.Libraries.Queries.Book.DTO;
using MediatR;

namespace Library.Application.Libraries.Queries.Book.GetBookByName
{
    public class GetBookByNameQuery : IRequest<BookResponseDto>
    {
        public string Name { get; set; }
    }
}
