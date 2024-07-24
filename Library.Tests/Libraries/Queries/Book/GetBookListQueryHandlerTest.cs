using AutoMapper;
using Library.Application.Libraries.Queries.Book.DTO;
using Library.Application.Libraries.Queries.Book.GetBookList;
using Library.Persistence;
using Library.Persistence.Repositories;
using Library.Tests.Common;
using Shouldly;

namespace Library.Tests.Libraries.Queries.Book
{
    [Collection("QueryCollection")]
    public class GetBookListQueryHandlerTest
    {
        private readonly LibraryDbContext _context;
        private readonly IMapper _mapper;
        private readonly BookRepository _bookRepository;

        public GetBookListQueryHandlerTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
            _bookRepository = fixture.BookRepository;
        }

        [Fact]
        public async void GetBookListQueryHandler_Success()
        {
            //Arrange
            var handler = new GetBookListQueryHandler(_bookRepository, _mapper);

            //Act
            var result = await handler.Handle(
                new GetBookListQuery(), CancellationToken.None);

            //Assert
            result.ShouldBeOfType<PagedResponse<BookResponseDto>>();
            result.Data.ToList().Count.ShouldBe(15);
        }

    }
}
