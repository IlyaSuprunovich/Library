using MediatR;

namespace Library.Application.Libraries.Queries.LibraryUser.GetTakenBooks
{
    public class GetTakenBooksListQuery : IRequest<TakenBooksListVm>
    {
        public Guid Id { get; set; }
    }
}
