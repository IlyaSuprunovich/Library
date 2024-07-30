using AutoMapper;
using Library.Application.Libraries.Commands.Book.DeleteBook;
using Library.Application.Libraries.Commands.Book.CreateBook;
using Library.Application.Libraries.Commands.Book.UpdateBook;
using Library.Application.Libraries.Queries.Book.GetBookDetails;
using Library.Application.Libraries.Queries.Book.GetBookList;
using Library.Application.Libraries.Queries.Book.GetBookByISBN;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Library.Application.Libraries.Commands.Book.TakeBook;
using Library.Application.Libraries.Commands.Book.ReturnBook;
using Library.Application.Libraries.Queries.Book.GetBookByName;
using Library.Application.Libraries.Queries.Book.GetBookGenreList;
using Library.Application.Libraries.Queries.Book.DTO;
using Library.Application.Libraries.Commands.Book.DTO;

namespace Library.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BookController : BaseController
    {
        private readonly IMapper _mapper;

        public BookController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        [AllowAnonymous]
        public async Task<ActionResult<PagedResponse<BookResponseDto>>> GetAll([FromQuery] int? pageNumber, 
            [FromQuery] int? pageSize, [FromQuery] string? genre, [FromQuery] string? name, 
            CancellationToken cancellationToken)
        {
            GetBookListQuery query = new()
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Genre = genre,
                Name = name
            };

            PagedResponse<BookResponseDto> dto = await Mediator.Send(query, cancellationToken);

            if(dto == null)
                return BadRequest();
            

            return Ok(dto);
        }

        [HttpGet("{id}")]
        [Authorize]
        [AllowAnonymous]
        public async Task<ActionResult<BookResponseDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            GetBookByIdQuery query = new()
            {
                Id = id
            };

            BookResponseDto dto = await Mediator.Send(query, cancellationToken);

            if (dto == null)
                return BadRequest();

            return Ok(dto);
        }

        [HttpGet("isbn/{isbn}")]
        [Authorize]
        [AllowAnonymous]
        public async Task<ActionResult<BookResponseDto>> GetByISBN(string isbn, 
            CancellationToken cancellationToken)
        {
            GetBookByISBNQuery query = new()
            {
                ISBN = isbn
            };

            BookResponseDto dto = await Mediator.Send(query, cancellationToken);

            if (dto == null)
                return BadRequest();

            return Ok(dto);
        }

        [HttpGet("by-name")]
        [Authorize]
        [AllowAnonymous]
        public async Task<ActionResult<BookResponseDto>> GetBookByName([FromQuery] string name, 
            CancellationToken cancellationToken)
        {
            GetBookByNameQuery query = new() 
            {
                Name = name 
            };

            BookResponseDto result = await Mediator.Send(query, cancellationToken);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpGet("genres")]
        [Authorize]
        [AllowAnonymous]
        public async Task<ActionResult<BookGenreListResponseDto>> GetBookGenres(
            CancellationToken cancellationToken)
        {
            GetBookGenreListQuery query = new();

            BookGenreListResponseDto result = await Mediator.Send(query, cancellationToken);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<Guid>> Create([FromForm] BookRequestDto createBookDto, 
            CancellationToken cancellationToken)
        {

            CreateBookCommand command = new()
            {
                Book = createBookDto
            };

            Guid bookId = await Mediator.Send(command, cancellationToken);

            if (bookId == Guid.Empty)
                return BadRequest();

            return Ok(bookId);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromForm] BookRequestDto updateBookDto, 
            CancellationToken cancellationToken)
        {

            UpdateBookCommand command = new()
            {
                Book = updateBookDto
            };

            await Mediator.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            DeleteBookCommand command = new()
            {
                Id = id
            };

            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpPut("give/{idBook}/{userId}")]
        [Authorize]
        public async Task<IActionResult> GiveBook(Guid idBook, Guid userId, 
            CancellationToken cancellationToken)
        {
            TakeBookCommand query = new()
            {
                Id = idBook,
                LibraryUserId = userId
            };

            await Mediator.Send(query, cancellationToken);
            return NoContent();
        }

        [HttpPut("return/{idBook}/{userId}")]
        [Authorize]
        public async Task<IActionResult> ReturnBook(Guid idBook, Guid userId, 
            CancellationToken cancellationToken)
        {
            ReturnBookCommand query = new()
            {
                Id = idBook,
                LibraryUserId = userId
            };

            await Mediator.Send(query, cancellationToken);
            return NoContent();
        }
    }
}
