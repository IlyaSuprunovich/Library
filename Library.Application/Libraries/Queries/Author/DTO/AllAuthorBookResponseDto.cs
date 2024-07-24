using Library.Application.Libraries.Queries.Book.DTO;

namespace Library.Application.Libraries.Queries.Author.DTO
{
    public class AllAuthorBookResponseDto
    {
        public IList<BookResponseDto> Books { get; set; }
    }
}
