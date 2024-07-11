using AutoMapper;
using Library.Application.Libraries.Commands.Author.CreateAuthor;
using Library.Application.Libraries.Commands.Author.UpdateAuthor;
using Library.Application.Libraries.Commands.Author.DeleteAuthor;
using Library.Application.Libraries.Queries.Author.GetAllAuthorBooks;
using Library.Application.Libraries.Queries.Author.GetAuthorDetails;
using Library.Application.Libraries.Queries.Author.GetAuthorList;
using Library.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [AllowAnonymous]
        public async Task<ActionResult<AuthorListVm>> GetAll()
        {
            GetAuthorListQuery query = new();
            AuthorListVm vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        [Authorize]
        [AllowAnonymous]
        public async Task<ActionResult<AuthorVm>> Get(Guid id)
        {
            GetAuthorByIdQuery query = new()
            {
                Id = id
            };

            AuthorVm vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("books/{authorId}")]
        [Authorize]
        [AllowAnonymous]
        public async Task<ActionResult<AllAuthorBookVm>> GetAllAuthorsBook(Guid authorId)
        {
            GetAllAuthorBookQuery query = new()
            {
                AuthorId = authorId
            };

            AllAuthorBookVm vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAuthorDto createAuthorDto)
        {
            CreateAuthorCommand command = _mapper.Map<CreateAuthorCommand>(createAuthorDto);

            Guid bookId = await Mediator.Send(command);
            return Ok(bookId);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateAuthorDto updateAuthorDto)
        {
            UpdateAuthorCommand command = _mapper.Map<UpdateAuthorCommand>(updateAuthorDto);

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteAuthorCommand command = new()
            {
                Id = id
            };

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
