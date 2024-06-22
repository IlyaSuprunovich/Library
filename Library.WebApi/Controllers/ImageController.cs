using AutoMapper;
using Library.Application.Libraries.Commands.Author.CreateAuthor;
using Library.Application.Libraries.Commands.Image;
using Library.Application.Libraries.Queries.Image;
using Library.WebApi.Models;
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

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromForm] UploadImageCommand command)
        {
            var imageId = await Mediator.Send(command);
            return Ok(imageId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageById(Guid id)
        {
            var image = await Mediator.Send(new GetImageByIdQuery(id));
            if (image == null)
            {
                return NotFound();
            }

            return File(image.Data, image.ContentType, image.FileName);
        }
    }
}
