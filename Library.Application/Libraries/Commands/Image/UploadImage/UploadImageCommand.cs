using Library.Application.Libraries.Commands.Image.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Library.Application.Libraries.Commands.Image.UploadImage
{
    public class UploadImageCommand : IRequest<Guid>
    {
        public UploadImageRequestDto Image { get; set; }
    }
}
