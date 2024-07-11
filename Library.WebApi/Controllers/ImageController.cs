using AutoMapper;
using Library.Application.Libraries.Commands.Image;
using Library.Application.Libraries.Queries.Image;
using Library.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : BaseController
    {
        private readonly IMapper _mapper;

        public ImageController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [Authorize]
        [AllowAnonymous]
        public async Task<IActionResult> GetImageById(Guid id)
        {
            Image image = await Mediator.Send(new GetImageByIdQuery(id));
            if (image == null)
            {
                return NotFound();
            }

            return File(image.Data, image.ContentType, image.FileName);
        }

        [HttpPost("upload")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UploadImage([FromForm] UploadImageCommand command)
        {
            Guid imageId = await Mediator.Send(command);
            return Ok(imageId);
        }
    }
}
