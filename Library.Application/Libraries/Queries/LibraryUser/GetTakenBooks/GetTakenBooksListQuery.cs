using Library.Application.Libraries.Queries.LibraryUser.DTO;
using MediatR;

namespace Library.Application.Libraries.Queries.LibraryUser.GetTakenBooks
{
    public class GetTakenBooksListQuery : IRequest<TakenBooksListResponseDto>
    {
        public Guid Id { get; set; }
    }
}
