using AutoMapper;
using Library.Application.Libraries.Queries.Book.GetBookList;
using Library.Persistence;
using Library.Tests.Common;
using Shouldly;

namespace Library.Tests.Libraries.Queries.Book
{
    [Collection("QueryCollection")]
    public class GetBookListQueryHandlerTest
    {
        private readonly LibraryDbContext _context;
        private readonly IMapper _mapper;

        public GetBookListQueryHandlerTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async void GetBookListQueryHandler_Success()
        {
            //Arrange
            var handler = new GetBookListQueryHandler(_context, _mapper);

            //Act
            var result = await handler.Handle(
                new GetBookListQuery(), CancellationToken.None);

            //Assert
            result.ShouldBeOfType<PagedResponse<BookLookupDto>>();
            result.Data.ToList().Count.ShouldBe(15);
        }

    }
}
