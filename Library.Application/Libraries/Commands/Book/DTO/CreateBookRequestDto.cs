using Microsoft.AspNetCore.Http;

namespace Library.Application.Libraries.Commands.Book.DTO
{
    public class CreateBookRequestDto
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public IFormFile File { get; set; }
    }
}
