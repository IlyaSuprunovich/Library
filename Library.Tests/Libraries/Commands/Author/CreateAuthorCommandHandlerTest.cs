using Library.Application.Libraries.Commands.Author.CreateAuthor;
using Library.Tests.Common;

namespace Library.Tests.Libraries.Commands.Author
{
    public class CreateAuthorCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task CreateAuthorCommandHandler_Success()
        {
            //Arrange
            var handler = new CreateAuthorCommandHandler(AuthorRepository);
            var name = "name";
            var surname = "surname";
            var dateOfBirth = DateTime.Now;
            var country = "country";
            var books = new List<Domain.Entities.Book>()
                    {
                        new()
                        {
                            Id = Guid.NewGuid(),
                            ISBN = "123",
                            Name = "bookName",
                            Genre = "genre",
                            Description = "description",
                        }
                    };

            //Act
            var bookId = await handler.Handle(
                new CreateAuthorCommand
                {
                    Author = new()
                    {
                        Name = name,
                        Surname = surname,
                        DateOfBirth = dateOfBirth,
                        Country = country,
                    }
                }, CancellationToken.None);

            //Assert
            var author = Context.Authors
                .AsEnumerable()
                .SingleOrDefault(author =>
                    author.Name == name && author.Surname == surname &&
                    author.DateOfBirth == dateOfBirth && author.Country == country);

            Assert.NotNull(author);
        }


    }
}
