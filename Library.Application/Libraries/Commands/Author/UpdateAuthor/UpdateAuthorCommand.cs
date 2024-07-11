using MediatR;

namespace Library.Application.Libraries.Commands.Author.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }

        public ICollection<Domain.Book> Books { get; set; }
    }
}
