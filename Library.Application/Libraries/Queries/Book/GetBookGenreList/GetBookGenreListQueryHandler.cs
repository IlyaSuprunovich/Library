using AutoMapper;
using Library.Application.Interfaces;
using Library.Application.Libraries.Queries.Book.GetBookList;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.Book.GetBookGenreList
{
    public class GetGenresListQueryHandler : IRequestHandler<GetBookGenreListQuery, BookGenreListVm>
    {
        private readonly ILibraryDbContext _libraryDbContext;

        public GetGenresListQueryHandler(ILibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public async Task<BookGenreListVm> Handle(GetBookGenreListQuery request, CancellationToken cancellationToken)
        {
            var genres = await _libraryDbContext.Books
                .Select(b => b.Genre)
                .Distinct()
                .ToListAsync(cancellationToken);

            var booksByGenre = new Dictionary<string, IList<BookLookupDto>>();

            foreach (var genre in genres)
            {
                var books = await _libraryDbContext.Books
                    .Where(b => b.Genre == genre)
                    .ToListAsync(cancellationToken);

                var bookLookupDtos = books.Select(b => new BookLookupDto
                {
                    Id = b.Id,
                    Image = b.Image,
                    Description = b.Description,
                    Genre = b.Genre,
                    ISBN = b.ISBN,
                    Name = b.Name,
                    Author = b.Author,
                }).ToList();

                booksByGenre.Add(genre, bookLookupDtos);
            }

            var result = new BookGenreListVm
            {
                Genres = genres,
                BooksByGenre = booksByGenre
            };

            return result;
        }
    }
}
