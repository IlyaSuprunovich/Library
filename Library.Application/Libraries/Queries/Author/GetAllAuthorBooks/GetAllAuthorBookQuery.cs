using MediatR;

namespace Library.Application.Libraries.Queries.Author.GetAllAuthorBooks
{
    public class GetAllAuthorBookQuery : IRequest<AllAuthorBookVm>
    {
        public Guid AuthorId { get; set; }
    }
}
