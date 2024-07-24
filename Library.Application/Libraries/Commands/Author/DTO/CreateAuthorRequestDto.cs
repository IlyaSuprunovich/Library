namespace Library.Application.Libraries.Commands.Author.DTO
{
    public class CreateAuthorRequestDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
    }
}
