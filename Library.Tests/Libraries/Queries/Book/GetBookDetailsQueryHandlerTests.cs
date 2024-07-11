using AutoMapper;
using Library.Application.Libraries.Queries.Book.GetBookDetails;
using Library.Persistence;
using Library.Tests.Common;
using Shouldly;

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
            var handler = new GetBookByIdQueryHandler(_context, _mapper);

            //Act
            var result = await handler.Handle(
                new GetBookByIdQuery
                {
                    Id = Guid.Parse("58dc909b-7f4a-4d4c-85e1-01a510780111")
                }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<BookVm>();
            result.ISBN.ShouldBe("9876543219876");
            result.Name.ShouldBe("Name2");
            result.Genre.ShouldBe("Genre2");
            result.Description.ShouldBe("asdfgh");
            result.Id.ShouldBe(Guid.Parse("58dc909b-7f4a-4d4c-85e1-01a510780111"));
        }
    }
}
