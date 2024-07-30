using Library.Application.Common.Exceptions;
using Library.Application.Libraries.Commands.Book.UpdateBook;
using Library.Tests.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Library.Tests.Libraries.Commands.Book
{
    public class UpdateBookCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task UpdateBookCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateBookCommandHandler(BookRepository, ImageRepository, Mediator, Mapper);
            var updateISBN = "new ISBN";
            var updateDescription = "new description";
            var updateGenre = "new genre";
            var updateName = "new name";

            var bookInDb = await Context.Books
            .Include(b => b.Image) 
            .SingleOrDefaultAsync(b => b.Id == LibraryContextFactory.BookIdForUpdate, 
                CancellationToken.None);
            Assert.NotNull(bookInDb);


            // Act
            var fileName = "testImage.jpg";
            var fileContent = "fake image content";
            var fileStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(fileContent));
            IFormFile file = new FormFile(fileStream, 0, fileStream.Length, "file", fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };

            await handler.Handle(new UpdateBookCommand
            {
                Book = new()
                {
                    Id = LibraryContextFactory.BookIdForUpdate,
                    ISBN = updateISBN,
                    Description = updateDescription,
                    Genre = updateGenre,
                    Name = updateName,
                    AuthorId = LibraryContextFactory.Id_B,
                    File = file
                }
            }, CancellationToken.None);

            // Assert
            var updatedBook = await Context.Books
                .Include(b => b.Image)
                .SingleOrDefaultAsync(book =>
                    book.Id == LibraryContextFactory.BookIdForUpdate &&
                    book.ISBN == updateISBN && 
                    book.Description == updateDescription &&
                    book.Genre == updateGenre && 
                    book.Name == updateName &&
                    book.AuthorId == LibraryContextFactory.Id_B);

            Assert.NotNull(updatedBook);
        }

        [Fact]
        public async Task UpdateBookCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new UpdateBookCommandHandler(BookRepository, ImageRepository, Mediator, Mapper);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateBookCommand
                    {
                        Book = new()
                        {
                            Id = Guid.NewGuid(),
                            AuthorId = LibraryContextFactory.Id_A
                        }
                    }, CancellationToken.None);
            });
        }
    }
}
