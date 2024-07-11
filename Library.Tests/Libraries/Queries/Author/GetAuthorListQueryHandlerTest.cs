using AutoMapper;
using Library.Application.Libraries.Queries.Author.GetAuthorList;
using Library.Persistence;
using Library.Tests.Common;
using Shouldly;

namespace Library.Tests.Libraries.Queries.Author
{
    [Collection("QueryCollection")]
    public class GetAuthorListQueryHandlerTest
    {
        private readonly LibraryDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorListQueryHandlerTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async void GetAuthorListQueryHandler_Success()
        {
            //Arrange
            var handler = new GetAuthorListQueryHandler(_context, _mapper);

            //Act
            var result = await handler.Handle(
                new GetAuthorListQuery
                {
                }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<AuthorListVm>();
            result.Authors.Count.ShouldBe(10);
        }
    }
}
