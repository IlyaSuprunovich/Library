using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Commands.Image
{
    public class UploadImageCommand : IRequest<Guid>
    {
        public IFormFile File { get; set; }

        /*public string FileName { get; set; }
        public byte[] Data { get; set; }
        public string ContentType { get; set; }*/
    }
}
