using Library.Application.Common.Exceptions;
using Library.Application.Libraries.Commands.Book.DeleteBook;
using Library.Tests.Common;

namespace Library.Tests.Libraries.Commands.Book
{
    public class DeleteBookCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task DeleteBookCommandHandler_Success()
        {
            //Arrange
            var handler = new DeleteBookCommandHandler(BookRepository, ImageRepository);

            var initialBook = new Domain.Entities.Book
            {
                Id = LibraryContextFactory.BookIdForDelete,
                ISBN = "ISBN",
                Description = "description",
                Genre = "genre",
                Name = "name",
                Author = new Domain.Entities.Author()
                {
                    Id = LibraryContextFactory.Id_B,
                    Name = "name",
                    Surname = "surname",
                    Country = "country",
                    DateOfBirth = DateTime.Now
                },
                AuthorId = LibraryContextFactory.Id_B,
                ImageId = LibraryContextFactory.ImageId
            };

            Context.Books.Add(initialBook);
            await Context.SaveChangesAsync();

            //Act
            await handler.Handle(new DeleteBookCommand
            {
                Id = LibraryContextFactory.BookIdForDelete
            }, CancellationToken.None);

            //Assert
            Assert.Null(Context.Books.SingleOrDefault(book =>
                book.Id == LibraryContextFactory.BookIdForDelete &&
                book.AuthorId == LibraryContextFactory.Id_A));
        }

        [Fact]
        public async Task DeleteBookCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new DeleteBookCommandHandler(BookRepository, ImageRepository);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new DeleteBookCommand
                    {
                        Id = Guid.NewGuid(),
                    }, CancellationToken.None);
            });
        }


    }
}
