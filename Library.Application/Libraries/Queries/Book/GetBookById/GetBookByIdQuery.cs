using MediatR;

namespace Library.Application.Libraries.Queries.Book.GetBookDetails
{
    public class GetBookByIdQuery : IRequest<BookVm>
    {
        public Guid Id { get; set; }
    }
}
