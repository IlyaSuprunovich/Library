using Library.Application.Libraries.Queries.Book.DTO;
using MediatR;

namespace Library.Application.Libraries.Queries.Book.GetBookByISBN
{
    public class GetBookByISBNQuery : IRequest<BookResponseDto>
    {
        public string ISBN { get; set; }
    }
}
