namespace Library.Application.Libraries.Commands.Author.DTO
{
    public class UpdateAuthorRequestDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }

        public ICollection<Domain.Entities.Book> Books { get; set; }
    }
}
