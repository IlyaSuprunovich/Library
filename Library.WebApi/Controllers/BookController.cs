using AutoMapper;
using Library.Application.Libraries.Commands.Book.DeleteBook;
using Library.Application.Libraries.Commands.Book.CreateBook;
using Library.Application.Libraries.Commands.Book.UpdateBook;
using Library.Application.Libraries.Queries.Book.GetBookDetails;
using Library.Application.Libraries.Queries.Book.GetBookList;
using Library.Application.Libraries.Queries.Book.GetBookByISBN;
using Library.Application.Libraries.Queries.Book.GetBookList;
using Library.Application.Libraries.Queries;
using Library.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Library.Application.Libraries.Commands.Book.TakeBook;
using Library.Application.Libraries.Queries.Book.TakeBook;
using Library.Application.Libraries.Commands.Book.ReturnBook;

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
        //[Authorize]
        public async Task<ActionResult<BookListVm>> GetAll()
        {
            var query = new GetBookListQuery()
            {
                AuthorId = new Guid("58dc909b-7f4a-4d4c-85e1-01a510780111")
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<BookDetailsVm>> Get(Guid id)
        {
            var query = new GetBookDetailsQuery()
            {
                //AuthorId = UserId,
                Id = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateBookDto createBookDto)
        {
            var command = _mapper.Map<CreateBookCommand>(createBookDto);
            //command.AuthorId = UserId;

            var bookId = await Mediator.Send(command);
            return Ok(bookId);
        }

        [HttpPut]
        //[Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateBookDto updateBookDto)
        {
            var command = _mapper.Map<UpdateBookCommand>(updateBookDto);
            //command.AuthorId = UserId;

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteBookCommand
            {
                Id = id,
                //AuthorId = UserId
            };

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet("isbn/{isbn}")]
        //[Authorize]
        public async Task<ActionResult<BookDetailsVm>> GetByISBN(string isbn)
        {
            var query = new GetBookByISBNQuery()
            {
                //AuthorId = UserId,
                ISBN = isbn
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPut("give/{idBook}")]
        //[Authorize]
        public async Task<IActionResult> GiveBook(Guid idBook)
        {
            //var command = _mapper.Map<TakeBookCommand>(updateBookDto);
            //command.AuthorId = UserId;

            var query = new TakeBookCommand()
            {
                Id = idBook,
                NumberReaderTicket = new Guid("58dc909b-7f4a-4d4c-85e1-01a510780111")
            };
        



            await Mediator.Send(query);
            return NoContent();
        }

        [HttpPut("return/{idBook}")]
        //[Authorize]
        public async Task<IActionResult> ReturnBook(Guid idBook)
        {
            //var command = _mapper.Map<TakeBookCommand>(updateBookDto);
            //command.AuthorId = UserId;

            var query = new ReturnBookCommand()
            {
                Id = idBook,
                NumberReaderTicket = new Guid("58dc909b-7f4a-4d4c-85e1-01a510780111")
            };




            await Mediator.Send(query);
            return NoContent();
        }
    }
}
