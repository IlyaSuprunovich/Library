using MediatR;

namespace Library.Application.Libraries.Queries.Book.GetBookList
{
    public class GetBookListQuery : IRequest<PagedResponse<BookLookupDto>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string? Genre { get; set; }  
        public string? Name {  get; set; }
    }
}
