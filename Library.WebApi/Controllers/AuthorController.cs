using AutoMapper;
using Library.Application.Commands.CreateBook;
using Library.Application.Commands.DeleteBook;
using Library.Application.Commands.UpdateBook;
using Library.Application.Libraries.Commands.CreateAuthor;
using Library.Application.Libraries.Commands.DeleteAuthor;
using Library.Application.Libraries.Commands.UpdateAuthor;
using Library.Application.Libraries.Queries.GetAuthorDetails;
using Library.Application.Libraries.Queries.GetAuthorList;
using Library.Application.Libraries.Queries.GetBookList;
using Library.Application.Libraries.Queries.GetLibraryDetails;
using Library.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<AuthorListVm>> GetAll()
        {
            var query = new GetAuthorListQuery()
            {
                Id = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
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
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAuthorDto createAuthorDto)
        {
            var command = _mapper.Map<CreateAuthorCommand>(createAuthorDto);
            command.Country = UserId.ToString();

            var bookId = await Mediator.Send(command);
            return Ok(bookId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAuthorDto updateAuthorDto)
        {
            var command = _mapper.Map<UpdateAuthorCommand>(updateAuthorDto);
            command.Country = UserId.ToString();

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteAuthorCommand
            {
                Id = id
            };

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
