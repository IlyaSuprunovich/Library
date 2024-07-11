using MediatR;
using Microsoft.AspNetCore.Http;

namespace Library.Application.Libraries.Commands.Image
{
    public class UploadImageCommand : IRequest<Guid>
    {
        public IFormFile File { get; set; }
        public Guid BookId { get; set; }
    }
}
