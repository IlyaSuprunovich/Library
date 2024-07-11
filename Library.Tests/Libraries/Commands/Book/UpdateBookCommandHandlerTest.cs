using Library.Application.Common.Exceptions;
using Library.Application.Libraries.Commands.Book.UpdateBook;
using Library.Tests.Common;
using Microsoft.EntityFrameworkCore;

namespace Library.Tests.Libraries.Commands.Book
{
    public class UpdateBookCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task UpdateBookCommandHandler_Success()
        {
            //Arrange
            var handler = new UpdateBookCommandHandler(Context);
            var updateISBN = "new ISBN";
            var updateDescription = "new description";
            var updateGenre = "new genre";
            var updateName = "new name";
            var updateAuthor = new Domain.Author()
            {
                Id = LibraryContextFactory.Id_B,
                Name = "name",
                Surname = "surname",
                Country = "country",
                DateOfBirth = DateTime.Now
            };


            var initialBook = new Domain.Book
            {
                Id = LibraryContextFactory.BookIdForUpdate,
                ISBN = "initial ISBN",
                Description = "initial description",
                Genre = "initial genre",
                Name = "initial name",
                Author = updateAuthor,
                AuthorId = LibraryContextFactory.Id_B
            };

            Context.Books.Add(initialBook);
            await Context.SaveChangesAsync();

            //Act
            await handler.Handle(new UpdateBookCommand
            {
                Id = LibraryContextFactory.BookIdForUpdate,
                ISBN = updateISBN,
                Description = updateDescription,
                Genre = updateGenre,
                Name = updateName,
                Author = updateAuthor,
                AuthorId = LibraryContextFactory.Id_B,
            }, CancellationToken.None);

            //Assert
            Assert.NotNull(await Context.Books.SingleOrDefaultAsync(book =>
                book.Id == LibraryContextFactory.BookIdForUpdate &&
                book.ISBN == updateISBN && book.Description == updateDescription &&
                book.Genre == updateGenre && book.Name == updateName &&
                book.Author == updateAuthor && book.AuthorId == LibraryContextFactory.Id_B));
        }

        [Fact]
        public async Task UpdateBookCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new UpdateBookCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateBookCommand
                    {
                        Id = Guid.NewGuid(),
                        AuthorId = LibraryContextFactory.Id_A
                    }, CancellationToken.None);
            });
        }
    }
}
