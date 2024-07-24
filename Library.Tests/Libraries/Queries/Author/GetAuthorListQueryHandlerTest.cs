using AutoMapper;
using Library.Application.Libraries.Queries.Author.DTO;
using Library.Application.Libraries.Queries.Author.GetAuthorList;
using Library.Persistence;
using Library.Persistence.Repositories;
using Library.Tests.Common;
using Shouldly;

namespace Library.Tests.Libraries.Queries.Author
{
    [Collection("QueryCollection")]
    public class GetAuthorListQueryHandlerTest
    {
        private readonly LibraryDbContext _context;
        private readonly IMapper _mapper;
        private readonly AuthorRepository _authorRepository;

        public GetAuthorListQueryHandlerTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
            _authorRepository = fixture.AuthorRepository;
        }

        [Fact]
        public async void GetAuthorListQueryHandler_Success()
        {
            //Arrange
            var handler = new GetAuthorListQueryHandler(_authorRepository, _mapper);

            //Act
            var result = await handler.Handle(
                new GetAuthorListQuery
                {
                }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<AuthorListResponseDto>();
            result.Authors.Count.ShouldBe(10);
        }
    }
}
