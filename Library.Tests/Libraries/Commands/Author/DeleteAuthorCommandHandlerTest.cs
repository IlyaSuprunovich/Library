using Library.Application.Common.Exceptions;
using Library.Application.Libraries.Commands.Author.DeleteAuthor;
using Library.Tests.Common;

namespace Library.Tests.Libraries.Commands.Author
{
    public class DeleteAuthorCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task DeleteAuthorCommandHandler_Success()
        {
            //Arrange
            var handler = new DeleteAuthorCommandHandler(AuthorRepository);
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

            var initialAuthor = new Domain.Entities.Author
            {
                Id = LibraryContextFactory.AuthorIdForDelete,
                Name = name,
                Surname = surname,
                DateOfBirth = dateOfBirth,
                Country = country,
                Books = books

            };

            Context.Authors.Add(initialAuthor);
            await Context.SaveChangesAsync();

            //Act
            await handler.Handle(new DeleteAuthorCommand
            {
                Id = LibraryContextFactory.AuthorIdForDelete
            }, CancellationToken.None);

            //Assert
            Assert.Null(Context.Authors.SingleOrDefault(author =>
                author.Id == LibraryContextFactory.AuthorIdForDelete));
        }

        [Fact]
        public async Task DeleteAuthorCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new DeleteAuthorCommandHandler(AuthorRepository);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new DeleteAuthorCommand
                    {
                        Id = Guid.NewGuid(),
                    }, CancellationToken.None);
            });
        }


    }
}
