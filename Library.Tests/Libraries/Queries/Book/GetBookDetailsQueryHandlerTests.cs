using AutoMapper;
using Library.Application.Libraries.Queries.Book.GetBookDetails;
using Library.Persistence;
using Library.Tests.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests.Libraries.Queries.Book
{
    [Collection("QueryCollection")]
    public class GetBookDetailsQueryHandlerTests
    {
        private readonly LibraryDbContext _context;
        private readonly IMapper _mapper;

        public GetBookDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetBookDetailsQueryHandler_Success()
        {
            //Arrange
            var handler = new GetBookDetailsQueryHandler(_context, _mapper);

            //Act
            var result = await handler.Handle(
                new GetBookDetailsQuery
                {
                    AuthorId = LibraryContextFactory.Id_B,
                    Id = Guid.Parse("58dc909b-7f4a-4d4c-85e1-01a510780111")
                }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<BookDetailsVm>();
            result.ISBN.ShouldBe("9876543219876");
            result.Name.ShouldBe("Name2");
            result.Genre.ShouldBe("Genre2");
            result.Description.ShouldBe("asdfgh");
            result.Id.ShouldBe(Guid.Parse("58dc909b-7f4a-4d4c-85e1-01a510780111"));
        }
    }
}
