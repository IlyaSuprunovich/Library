using AutoMapper;
using Library.Application.Libraries.Queries.Author.DTO;
using Library.Application.Libraries.Queries.Author.GetAuthorDetails;
using Library.Persistence;
using Library.Persistence.Repositories;
using Library.Tests.Common;
using Shouldly;

namespace Library.Tests.Libraries.Queries.Author
{
    [Collection("QueryCollection")]
    public class GetAuthorDetailsQueryHandlerTest
    {
        private readonly LibraryDbContext _context;
        private readonly IMapper _mapper;
        private readonly AuthorRepository _authorRepository;

        public GetAuthorDetailsQueryHandlerTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
            _authorRepository = fixture.AuthorRepository;
        }

        [Fact]
        public async Task GetAuthorDetailsQueryHandler_Success()
        {
            //Arrange
            var handler = new GetAuthorByIdQueryHandler(_authorRepository, _mapper);

            //Act
            var result = await handler.Handle(
                new GetAuthorByIdQuery
                {
                    Id = Guid.Parse("17dc9090-26e4-45ac-8934-5aa052858555")
                }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<AuthorResponseDto>();
            result.Id.ShouldBe(Guid.Parse("17dc9090-26e4-45ac-8934-5aa052858555"));
            result.Name.ShouldBe("Name1");
            result.Surname.ShouldBe("Surname1");
            result.DateOfBirth.ShouldBe(new DateTime(1234, 10, 5));
            result.Country.ShouldBe("Country1");

        }
    }
}
