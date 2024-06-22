using AutoMapper;
using Library.Application.Libraries.Queries.Author.GetAuthorDetails;
using Library.Application.Libraries.Queries.Book.GetBookDetails;
using Library.Persistence;
using Library.Tests.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests.Libraries.Queries.Author
{
    [Collection("QueryCollection")]
    public class GetAuthorDetailsQueryHandlerTest
    {
        private readonly LibraryDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorDetailsQueryHandlerTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetAuthorDetailsQueryHandler_Success()
        {
            //Arrange
            var handler = new GetAuthorDetailsQueryHandler(_context, _mapper);

            //Act
            var result = await handler.Handle(
                new GetAuthorDetailsQuery
                {
                    Id = Guid.Parse("17dc9090-26e4-45ac-8934-5aa052858555")
                }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<AuthorDetailsVm>();
            result.Id.ShouldBe(Guid.Parse("17dc9090-26e4-45ac-8934-5aa052858555"));
            result.Name.ShouldBe("Name1");
            result.Surname.ShouldBe("Surname1");
            result.DateOfBirth.ShouldBe(new DateTime(1234, 10, 5));
            result.Country.ShouldBe("Country1");
            
        }
    }
}
