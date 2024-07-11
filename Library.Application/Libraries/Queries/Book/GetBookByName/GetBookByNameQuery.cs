using MediatR;

namespace Library.Application.Libraries.Queries.Book.GetBookByName
{
    public class GetBookByNameQuery : IRequest<BookByNameLookupDto>
    {
        public string Name { get; set; }
    }
}
