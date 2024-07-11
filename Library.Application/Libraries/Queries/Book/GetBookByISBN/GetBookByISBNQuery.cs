using MediatR;

namespace Library.Application.Libraries.Queries.Book.GetBookByISBN
{
    public class GetBookByISBNQuery : IRequest<BookByISBNVm>
    {
        public string ISBN { get; set; }
    }
}
