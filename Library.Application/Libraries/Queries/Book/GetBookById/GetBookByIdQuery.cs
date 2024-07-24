using Library.Application.Libraries.Queries.Book.DTO;
using MediatR;

namespace Library.Application.Libraries.Queries.Book.GetBookDetails
{
    public class GetBookByIdQuery : IRequest<BookResponseDto>
    {
        public Guid Id { get; set; }
    }
}
