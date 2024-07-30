using Library.Tests.Common;
using Library.Application.Libraries.Commands.Book.CreateBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Library.Domain;
using Microsoft.AspNetCore.Http;

namespace Library.Tests.Libraries.Commands.Book
{
    public class CreateBookCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task CreateBookCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateBookCommandHandler(AuthorRepository, BookRepository, Mediator, Mapper);
            var bookName = "book name";
            var bookDescription = "book details";
            var bookISBN = "1234567891234";
            var bookGenre = "book genre";

            var bookAuthor = new Domain.Entities.Author
            {
                Id = Guid.NewGuid(),
                Name = "authorName",
                Surname = "authorSurname",
                Country = "authorCountry",
                DateOfBirth = DateTime.Now
            };

            Context.Authors.Add(bookAuthor);
            await Context.SaveChangesAsync();

            var fileName = "testImage.jpg";
            var fileContent = "fake image content";
            var fileStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(fileContent));
            IFormFile file = new FormFile(fileStream, 0, fileStream.Length, "file", fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };


            // Act
            var bookId = await handler.Handle(
                new CreateBookCommand
                {
                    Book = new()
                    {
                        Name = bookName,
                        Description = bookDescription,
                        ISBN = bookISBN,
                        Genre = bookGenre,
                        AuthorId = bookAuthor.Id,
                        File = file
                    }
                }, CancellationToken.None);

            // Assert
            var createdBook = await Context.Books.SingleOrDefaultAsync(book =>
                book.Id == bookId && book.Name == bookName &&
                book.Description == bookDescription && book.ISBN == bookISBN &&
                book.Genre == bookGenre && book.AuthorId == bookAuthor.Id);

            Assert.NotNull(createdBook);
        }
    }
}
