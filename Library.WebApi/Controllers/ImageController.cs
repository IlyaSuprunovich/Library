using AutoMapper;
using Library.Application.Libraries.Commands.Image.DTO;
using Library.Application.Libraries.Commands.Image.UploadImage;
using Library.Application.Libraries.Queries.Image;
using Library.Application.Libraries.Queries.Image.DTO;
using Library.Application.Libraries.Queries.Image.GetImageById;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;

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
        public async Task<IActionResult> GetImageById(Guid id, CancellationToken cancellationToken)
        {
            ImageResponseDto image = await Mediator.Send(new GetImageByIdQuery(id), cancellationToken);
            if (image == null)
            {
                return BadRequest();
            }

            return File(System.IO.File.ReadAllBytes(image.Path), image.ContentType, image.FileName);
        }

        [HttpPost("upload")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UploadImage(
            [FromForm] UploadImageRequestDto uploadImageRequestDto, CancellationToken cancellationToken)
        {
            UploadImageCommand command = new()
            {
                Image = uploadImageRequestDto
            };

            Guid imageId = await Mediator.Send(command, cancellationToken);

            if (imageId == Guid.Empty)
                return BadRequest();

            return Ok(imageId);
        }
    }
}
