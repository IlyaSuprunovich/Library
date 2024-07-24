using Library.Persistence;
using Microsoft.EntityFrameworkCore;
using Library.Domain.Entities;
using System.IO;

namespace Library.Tests.Common
{
    public class LibraryContextFactory
    {
        public static Guid Id_A = Guid.NewGuid();
        public static Guid Id_B = Guid.NewGuid();

        public static Guid BookIdForDelete = Guid.Parse("10ca202e-dfb4-4d97-b7ef-76cf510bf319");
        public static Guid BookIdForUpdate = Guid.Parse("20ca202e-dfb4-4d97-b7ef-76cf510bf319");

        public static Guid AuthorIdForDelete = Guid.Parse("00ca202e-dfb4-4d97-b7ef-76cf510bf319");
        public static Guid AuthorIdForUpdate = Guid.Parse("00ca202e-dfb4-4d97-b7ef-76cf510bf319");

        public static LibraryDbContext Create()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new LibraryDbContext(options);
            context.Database.EnsureCreated();
            context.Authors.Add(
                new Author
                {
                    Id = Guid.Parse("17dc9090-26e4-45ac-8934-5aa052858555"),
                    Name = "Name1",
                    Surname = "Surname1",
                    DateOfBirth = new DateTime(1234, 10, 5),
                    Country = "Country1",
                    Books = new List<Book>()
                    {
                        new Book
                        {
                            Id = Guid.Parse("19dc9090-26e4-45ac-8934-5aa052858919"),
                            ISBN = "123",
                            Name = "Name",
                            Genre = "Genre",
                            Description = "456",
                            Author = new Author()
                            {
                                Name = "Name",
                                Surname = "Surname",
                                Country = "Country"
                            },
                            AuthorId = Guid.Parse("99dc9090-26e4-45ac-8934-5aa052858123"),
                            IsBookInLibrary = true,
                            TimeOfTake = null,
                            TimeOfReturn = null,
                            Image = null,
                            ImageId = Guid.Parse("55dc9090-26e4-45ac-8934-5aa052858123")
                        }
                    }
                });
            context.Books.AddRange(
                new Book
                {
                    Id = BookIdForUpdate,
                    ISBN = "1234567891234",
                    Name = "Name1",
                    Genre = "Genre1",
                    Description = "qwerty",
                    Author = new Author()
                    {
                        Name = "Name1",
                        Surname = "Surname1",
                        Country = "Country1"
                    },
                    AuthorId = Guid.Parse("89dc9090-26e4-45ac-8934-5aa052858123"),
                    IsBookInLibrary = true,
                    TimeOfTake = null,
                    TimeOfReturn = null,
                    Image = null,
                    ImageId = Guid.Parse("56dc9090-26e4-45ac-8934-5aa052858123")
                },

                new Book
                {
                    Id = Guid.Parse("58dc909b-7f4a-4d4c-85e1-01a510780111"),
                    ISBN = "9876543219876",
                    Name = "Name2",
                    Genre = "Genre2",
                    Description = "asdfgh",
                    Author = new Author()
                    {
                        Name = "Name2",
                        Surname = "Surname2",
                        Country = "Country2"
                    },
                    AuthorId = Guid.Parse("11dc909b-7f4a-4d4c-85e1-01a510780111"),
                    IsBookInLibrary = true,
                    TimeOfTake = null,
                    TimeOfReturn = null,
                    Image = null,
                    ImageId = Guid.Parse("20dc909b-7f4a-4d4c-85e1-01a510780111")
                },

                new Book
                {
                    Id = Guid.Parse("66dc909b-7f4a-4d4c-85e1-01a510780666"),
                    ISBN = "7418529637418",
                    Name = "Name3",
                    Genre = "Genre3",
                    Description = "zxcvbn",
                    Author = new Author()
                    {
                        Name = "Name3",
                        Surname = "Surname3",
                        Country = "Country3"
                    },
                    AuthorId = Guid.Parse("42dc909b-7f4a-4d4c-85e1-01a510780666"),
                    IsBookInLibrary = true,
                    TimeOfTake = null,
                    TimeOfReturn = null,
                    Image = null,
                    ImageId = Guid.Parse("83dc909b-7f4a-4d4c-85e1-01a510780666")
                },

                new Book
                {
                    Id = Guid.Parse("29dc909b-7f4a-4d4c-85e1-01a510780753"),
                    ISBN = "8529637418529",
                    Name = "Name4",
                    Genre = "Genre4",
                    Description = "fghjkl",
                    Author = new Author()
                    {
                        Name = "Name4",
                        Surname = "Surname4",
                        Country = "Country4"
                    },
                    AuthorId = Guid.Parse("05dc909b-7f4a-4d4c-85e1-01a510780753"),
                    IsBookInLibrary = true,
                    TimeOfTake = null,
                    TimeOfReturn = null,
                    Image = null,
                    ImageId = Guid.Parse("44dc909b-7f4a-4d4c-85e1-01a510780753")
                }
            );

            context.Images.Add(
                new Image()
                {
                    Id = new Guid("56dc9090-26e4-45ac-8934-5aa052858123"),
                    FileName = "image.jpeg",
                    Path = $"image.jpeg",
                    ContentType = "image/jpeg"
                });

            context.SaveChanges();
            return context;
        }

        public static void Destroy(LibraryDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
