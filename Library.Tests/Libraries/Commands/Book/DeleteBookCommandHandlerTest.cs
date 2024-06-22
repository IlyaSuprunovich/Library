﻿using Library.Application.Common.Exceptions;
using Library.Application.Libraries.Commands.Book.CreateBook;
using Library.Application.Libraries.Commands.Book.DeleteBook;
using Library.Domain;
using Library.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests.Libraries.Commands.Book
{
    public class DeleteBookCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task DeleteBookCommandHandler_Success()
        {
            //Arrange
            var handler = new DeleteBookCommandHandler(Context);

            var initialBook = new Domain.Book
            {
                Id = LibraryContextFactory.BookIdForUpdate,
                ISBN = "ISBN",
                Description = "description",
                Genre = "genre",
                Name = "name",
                Author = new Domain.Author()
                {
                    Id = LibraryContextFactory.Id_B,
                    Name = "name",
                    Surname = "surname",
                    Country = "country",
                    DateOfBirth = DateTime.Now
                },
                AuthorId = LibraryContextFactory.Id_B
            };

            Context.Books.Add(initialBook);
            await Context.SaveChangesAsync();

            //Act
            await handler.Handle(new DeleteBookCommand
            {
                Id = LibraryContextFactory.BookIdForDelete,
                AuthorId = LibraryContextFactory.Id_A
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
            var handler = new DeleteBookCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new DeleteBookCommand
                    {
                        Id = Guid.NewGuid(),
                        AuthorId = LibraryContextFactory.Id_A
                    }, CancellationToken.None);
            });
        }


    }
}
