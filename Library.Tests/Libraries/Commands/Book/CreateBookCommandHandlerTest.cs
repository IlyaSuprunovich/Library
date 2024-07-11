using Library.Tests.Common;
using Library.Application.Libraries.Commands.Book.CreateBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Library.Domain;

namespace Library.Tests.Libraries.Commands.Book
{
    public class CreateBookCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task CreateBookCommandHandler_Success()
        {
            //Arrange
            var handler = new CreateBookCommandHandler(Context);
            var bookName = "book name";
            var bookDescription = "book details";
            var bookISBN = "1234567891234";
            var bookGenre = "book genre";
            var bookAuthor = new Domain.Author()
            {
                Name = "authorName",
                Surname = "authorSurname",
                Country = "authorCountry"
            };
            var bookAuthorId = Guid.NewGuid();

            //Act
            var bookId = await handler.Handle(
                new CreateBookCommand
                {
                    Name = bookName,
                    Description = bookDescription,
                    ISBN = bookISBN,
                    Genre = bookGenre,
                    Author = bookAuthor,
                    AuthorId = bookAuthorId
                }, CancellationToken.None);

            //Assert
            Assert.NotNull(
                Context.Books.SingleOrDefaultAsync(book =>
                book.Id == bookId && book.Name == bookName &&
                book.Description == bookDescription && book.ISBN == bookISBN &&
                book.Genre == bookGenre && book.Author == bookAuthor && book.AuthorId == bookAuthorId));
        }
    }
}
