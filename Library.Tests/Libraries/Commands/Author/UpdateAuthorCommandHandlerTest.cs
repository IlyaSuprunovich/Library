﻿using Library.Application.Common.Exceptions;
using Library.Application.Libraries.Commands.Author.DeleteAuthor;
using Library.Application.Libraries.Commands.Author.UpdateAuthor;
using Library.Application.Libraries.Commands.Book.UpdateBook;
using Library.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.Tests.Libraries.Commands.Author
{
    public class UpdateAuthorCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task UpdateAuthorCommandHandler_Success()
        {
            
            //Arrange
            var handler = new UpdateAuthorCommandHandler(Context);
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

            var initialAuthor = new Domain.Author
            {
                Id = LibraryContextFactory.AuthorIdForUpdate,
                Name = name,
                Surname = surname,
                DateOfBirth = dateOfBirth,
                Country = country,
                Books = books

            };

            Context.Authors.Add(initialAuthor);
            await Context.SaveChangesAsync();

            //Act
            await handler.Handle(new UpdateAuthorCommand
            {
                Id = LibraryContextFactory.BookIdForUpdate,
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

        [Fact]
        public async Task UpdateAuthorCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new UpdateAuthorCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateAuthorCommand
                    {
                        Id = Guid.NewGuid(),
                        Name = "name",
                        Surname = "surname",
                        DateOfBirth = DateTime.Now,
                        Country = "country",
                        Books = new List<Domain.Book>()
                        {
                            new()
                            {
                                Id = Guid.NewGuid(),
                                ISBN = "123",
                                Name = "bookName",
                                Genre = "genre",
                                Description = "description",
                            }
                        }
                    }, CancellationToken.None);
            });
        }
    }
}