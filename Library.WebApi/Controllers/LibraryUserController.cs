using AutoMapper;
using Library.Application.Libraries.Queries.LibraryUser.GetTakenBooks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class LibraryUserController : BaseController
    {
        private readonly IMapper _mapper;

        public LibraryUserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("userId/{userId}")]
        [Authorize]
        [AllowAnonymous]
        public async Task<ActionResult<TakenBooksListVm>> GetById(Guid userId)
        {
            GetTakenBooksListQuery query = new()
            {
                Id = userId
            };

            TakenBooksListVm vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
