using Library.Application.Libraries.Commands.Author.CreateAuthor;
using Library.Application.Libraries.Commands.Book.CreateBook;
using Library.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests.Libraries.Commands.Author
{
    public class CreateAuthorCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task CreateAuthorCommandHandler_Success()
        {
            //Arrange
            var handler = new CreateAuthorCommandHandler(Context);
            var name = "name";
            var surname = "surname";
            var dateOfBirth = DateTime.Now;
            var country = "country";
            var books = new List<Domain.Book>()
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
                    Name = name,
                    Surname = surname,
                    DateOfBirth = dateOfBirth,
                    Country = country,
                    Books = books
                }, CancellationToken.None);

            //Assert
            var author = Context.Authors
                .AsEnumerable()
                .SingleOrDefault(author =>
                    author.Name == name && author.Surname == surname &&
                    author.DateOfBirth == dateOfBirth && author.Country == country &&
                    author.Books.SequenceEqual(books));

            Assert.NotNull(author);
        }


    }
}
