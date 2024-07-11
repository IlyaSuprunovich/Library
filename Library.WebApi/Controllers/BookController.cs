using AutoMapper;
using Library.Application.Libraries.Commands.Book.DeleteBook;
using Library.Application.Libraries.Commands.Book.CreateBook;
using Library.Application.Libraries.Commands.Book.UpdateBook;
using Library.Application.Libraries.Queries.Book.GetBookDetails;
using Library.Application.Libraries.Queries.Book.GetBookList;
using Library.Application.Libraries.Queries.Book.GetBookByISBN;
using Library.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Library.Application.Libraries.Commands.Book.TakeBook;
using Library.Application.Libraries.Commands.Book.ReturnBook;
using Library.Application.Libraries.Queries.Book.GetBookByName;
using Library.Application.Libraries.Queries.Book.GetBookGenreList;

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
        public async Task<ActionResult<PagedResponse<BookLookupDto>>> GetAll([FromQuery] int? pageNumber, 
            [FromQuery] int? pageSize, [FromQuery] string? genre, [FromQuery] string? name)
        {
            GetBookListQuery query = new()
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Genre = genre,
                Name = name
            };

            PagedResponse<BookLookupDto> vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        [Authorize]
        [AllowAnonymous]
        public async Task<ActionResult<BookVm>> Get(Guid id)
        {
            GetBookByIdQuery query = new()
            {
                Id = id
            };

            BookVm vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("isbn/{isbn}")]
        [Authorize]
        [AllowAnonymous]
        public async Task<ActionResult<BookByISBNVm>> GetByISBN(string isbn)
        {
            GetBookByISBNQuery query = new()
            {
                ISBN = isbn
            };

            BookByISBNVm vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("by-name")]
        [Authorize]
        [AllowAnonymous]
        public async Task<ActionResult<BookByNameLookupDto>> GetBookByName([FromQuery] string name)
        {
            GetBookByNameQuery query = new() 
            {
                Name = name 
            };

            BookByNameLookupDto result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("genres")]
        [Authorize]
        [AllowAnonymous]
        public async Task<ActionResult<BookGenreListVm>> GetBookGenres()
        {
            GetBookGenreListQuery query = new();

            BookGenreListVm result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateBookDto createBookDto)
        {
            CreateBookCommand command = _mapper.Map<CreateBookCommand>(createBookDto);

            Guid bookId = await Mediator.Send(command);
            return Ok(bookId);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateBookDto updateBookDto)
        {
            UpdateBookCommand command = _mapper.Map<UpdateBookCommand>(updateBookDto);

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteBookCommand command = new()
            {
                Id = id
            };

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("give/{idBook}/{userId}")]
        [Authorize]
        public async Task<IActionResult> GiveBook(Guid idBook, Guid userId)
        {
            TakeBookCommand query = new()
            {
                Id = idBook,
                LibraryUserId = userId
            };

            await Mediator.Send(query);
            return NoContent();
        }

        [HttpPut("return/{idBook}/{userId}")]
        [Authorize]
        public async Task<IActionResult> ReturnBook(Guid idBook, Guid userId)
        {
            ReturnBookCommand query = new()
            {
                Id = idBook,
                LibraryUserId = userId
            };

            await Mediator.Send(query);
            return NoContent();
        }
    }
}
