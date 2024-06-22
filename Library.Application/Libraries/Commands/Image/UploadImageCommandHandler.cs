using Library.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Commands.Image
{
    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, Guid>
    {
        private readonly ILibraryDbContext _libraryDbContext;

        public UploadImageCommandHandler(ILibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public async Task<Guid> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            if (request.File == null || request.File.Length == 0)
            {
                throw new Exception("Invalid file.");
            }

            using (var memoryStream = new MemoryStream())
            {
                await request.File.CopyToAsync(memoryStream);

                var image = new Domain.Image
                {
                    Id = Guid.NewGuid(),
                    FileName = request.File.FileName,
                    Data = memoryStream.ToArray(),
                    ContentType = request.File.ContentType
                };

                await _libraryDbContext.Images.AddAsync(image);
                await _libraryDbContext.SaveChangesAsync(cancellationToken);

                return image.Id;
            }
        }
    }
}
