using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Library.Application.Libraries.Commands.Image.UploadImage
{
    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, Guid>
    {
        private readonly IImageRepository _imageRepository;
        private readonly IBookRepository _bookRepository;

        public UploadImageCommandHandler(IImageRepository imageRepository,
            IBookRepository bookRepository)
        {
            _imageRepository = imageRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Guid> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            if (request.Image.File == null || request.Image.File.Length == 0)
                throw new Exception("Invalid file.");

            Domain.Entities.Book? book = await _bookRepository.GetByIdAsync(request.Image.BookId,
                cancellationToken);

            if (book is not { })
                throw new NotFoundException(nameof(Domain.Entities.Book), request.Image.BookId);

            if (File.Exists(book?.Image?.Path))
                File.Delete(book.Image.Path);

            string[] currentDirectory = Directory.GetCurrentDirectory().Split('\\');
            currentDirectory[currentDirectory.Length - 1] = "Library.Persistence\\Image\\";
            string path = Path.Combine(currentDirectory);

            Domain.Entities.Image newImage = new()
            {
                FileName = request.Image.File.FileName,
                Path = $"{path}{request.Image.File.FileName}",
                ContentType = request.Image.File.ContentType,
            };

            await _imageRepository.AddAsync(newImage, cancellationToken);

            book.ImageId = newImage.Id;
            book.Image = newImage;

            await _imageRepository.SaveChangesAsync(cancellationToken);

            using (FileStream fileStream = new($"{path}{request.Image.File.FileName}", FileMode.Create))
            {
                await request.Image.File.CopyToAsync(fileStream, cancellationToken);
            }

            return newImage.Id;
        }
    }
}
