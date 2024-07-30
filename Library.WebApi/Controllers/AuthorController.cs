using AutoMapper;
using Library.Application.Libraries.Commands.Author.CreateAuthor;
using Library.Application.Libraries.Commands.Author.UpdateAuthor;
using Library.Application.Libraries.Commands.Author.DeleteAuthor;
using Library.Application.Libraries.Queries.Author.GetAllAuthorBooks;
using Library.Application.Libraries.Queries.Author.GetAuthorDetails;
using Library.Application.Libraries.Queries.Author.GetAuthorList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Library.Application.Libraries.Queries.Author.DTO;
using Library.Application.Libraries.Commands.Author.DTO;

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
        public async Task<ActionResult<AuthorListResponseDto>> GetAll(
            CancellationToken cancellationToken)
        {
            GetAuthorListQuery query = new();
            AuthorListResponseDto dto = await Mediator.Send(query, cancellationToken);

            if (dto == null)
                return BadRequest();

            return Ok(dto);
        }

        [HttpGet("{id}")]
        [Authorize]
        [AllowAnonymous]
        public async Task<ActionResult<AuthorResponseDto>> Get(Guid id, 
            CancellationToken cancellationToken)
        {
            GetAuthorByIdQuery query = new()
            {
                Id = id
            };

            AuthorResponseDto dto = await Mediator.Send(query, cancellationToken);

            if (dto == null)
                return BadRequest();

            return Ok(dto);
        }

        [HttpGet("books/{authorId}")]
        [Authorize]
        [AllowAnonymous]
        public async Task<ActionResult<AllAuthorBookResponseDto>> GetAllAuthorsBook(Guid authorId, 
            CancellationToken cancellationToken)
        {
            GetAllAuthorBookQuery query = new()
            {
                AuthorId = authorId
            };

            AllAuthorBookResponseDto dto = await Mediator.Send(query, cancellationToken);

            if (dto == null)
                return BadRequest();

            return Ok(dto);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<Guid>> Create([FromBody] AuthorRequestDto createAuthorDto, 
            CancellationToken cancellationToken)
        {
            CreateAuthorCommand command = new()
            {
                Author = createAuthorDto
            };

            Guid bookId = await Mediator.Send(command, cancellationToken);

            if (bookId == Guid.Empty)
                return BadRequest();

            return Ok(bookId);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromBody] AuthorRequestDto updateAuthorDto, 
            CancellationToken cancellationToken)
        {
            UpdateAuthorCommand command = new()
            {
                Author = updateAuthorDto
            };

            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            DeleteAuthorCommand command = new()
            {
                Id = id
            };

            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
