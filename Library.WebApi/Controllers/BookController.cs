using AutoMapper;
using Library.Application.Commands.CreateBook;
using Library.Application.Commands.DeleteBook;
using Library.Application.Commands.UpdateBook;
using Library.Application.Libraries.Queries.GetBookList;
using Library.Application.Libraries.Queries.GetLibraryDetails;
using Library.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<BookListVm>> GetAll()
        {
            var query = new GetBookListQuery() 
            {
                AuthorId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailsVm>> Get(Guid id)
        {
            var query = new GetBookDetailsQuery()
            {
                AuthorId = UserId,
                Id = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateBookDto createBookDto)
        {
            var command = _mapper.Map<CreateBookCommand>(createBookDto);
            command.AuthorId = UserId;

            var bookId = await Mediator.Send(command);
            return Ok(bookId);  
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBookDto updateBookDto)
        {
            var command = _mapper.Map<UpdateBookCommand>(updateBookDto);
            command.AuthorId = UserId;

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteBookCommand
            {
                Id = id,
                AuthorId = UserId
            };

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
