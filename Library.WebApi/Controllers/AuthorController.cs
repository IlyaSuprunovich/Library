using AutoMapper;
using Library.Application.Libraries.Commands.Book.CreateBook;
using Library.Application.Libraries.Commands.Book.DeleteBook;
using Library.Application.Libraries.Commands.Book.UpdateBook;
using Library.Application.Libraries.Commands.Author.CreateAuthor;
using Library.Application.Libraries.Commands.Author.UpdateAuthor;
using Library.Application.Libraries.Commands.Author.DeleteAuthor;
using Library.Application.Libraries.Queries.Author.GetAllAuthorBooks;
using Library.Application.Libraries.Queries.Author.GetAuthorDetails;
using Library.Application.Libraries.Queries.Author.GetAuthorList;
using Library.Application.Libraries.Queries.Author.GetAllAuthorBooks;
using Library.Application.Libraries.Queries.Author.GetAuthorDetails;
using Library.Application.Libraries.Queries.Author.GetAuthorList;
using Library.Application.Libraries.Queries.Book.GetBookList;
using Library.Application.Libraries.Queries;
using Library.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Library.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : BaseController
    {
        private readonly IMapper _mapper;

        public AuthorController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<AuthorListVm>> GetAll()
        {
            var query = new GetAuthorListQuery()
            {
                Id = new Guid("12dc9090-26e4-45ac-8934-5aa052858123")
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<AuthorDetailsVm>> Get(Guid id)
        {
            var query = new GetAuthorDetailsQuery()
            {
                Id = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAuthorDto createAuthorDto)
        {
            var command = _mapper.Map<CreateAuthorCommand>(createAuthorDto);

            var bookId = await Mediator.Send(command);
            return Ok(bookId);
        }

        [HttpPut]
        //[Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateAuthorDto updateAuthorDto)
        {
            var command = _mapper.Map<UpdateAuthorCommand>(updateAuthorDto);

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteAuthorCommand
            {
                Id = id
            };

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet("books/{authorId}")]
        //[Authorize]
        public async Task<ActionResult<AllAuthorBookVm>> GetAllAuthorsBook(Guid authorId)
        {
            var query = new GetAllAuthorBookQuery()
            {
                UserId = new Guid("58dc909b-7f4a-4d4c-85e1-01a510780111")
            };
            var vm = await Mediator.Send(query);

            
            //List<AllAuthorBookLookupDto> sortedVm = .ToList();

            return Ok(vm.Books.Where(x => x.AuthorId == authorId));
        }
    }
}
