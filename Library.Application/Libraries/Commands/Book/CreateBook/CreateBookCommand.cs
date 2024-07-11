using MediatR;

namespace Library.Application.Libraries.Commands.Book.CreateBook
{
    public class CreateBookCommand : IRequest<Guid>
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public Domain.Author? Author { get; set; }
        public Guid AuthorId { get; set; }
        public int CountBook { get; set; }
        public Guid ImageId { get; set; }
    }
}