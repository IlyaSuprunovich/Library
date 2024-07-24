using AutoMapper;
using Library.Application.Libraries.Queries.LibraryUser.DTO;
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
        public async Task<ActionResult<TakenBooksListResponseDto>> GetById(Guid userId, 
            CancellationToken cancellationToken)
        {
            GetTakenBooksListQuery query = new()
            {
                Id = userId
            };

            TakenBooksListResponseDto dto = await Mediator.Send(query, cancellationToken);

            if (dto == null)
                return BadRequest();

            return Ok(dto);
        }
    }
}
