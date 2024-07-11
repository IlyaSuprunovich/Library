using MediatR;

namespace Library.Application.Libraries.Queries.Author.GetAuthorDetails
{
    public class GetAuthorByIdQuery : IRequest<AuthorVm>
    {
        public Guid Id { get; set; }
    }
}
