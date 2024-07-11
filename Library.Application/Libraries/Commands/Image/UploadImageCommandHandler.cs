using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

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

            Domain.Book? book = await _libraryDbContext.Books
                .FindAsync(new object[] { request.BookId });

            if (book is not { })
                throw new NotFoundException(nameof(Domain.Book), request.BookId);

            Domain.Image? existingImage = await _libraryDbContext.Images
                .FirstOrDefaultAsync(image => image.BookId == book.Id);

            using (MemoryStream memoryStream = new())
            {
                await request.File.CopyToAsync(memoryStream);

                Domain.Image newImage = new()
                {
                    FileName = request.File.FileName,
                    Data = memoryStream.ToArray(),
                    ContentType = request.File.ContentType,
                    Book = book
                };

                if (existingImage != null)
                {
                    // Удаляем старое изображение
                    _libraryDbContext.Images.Remove(existingImage);
                }

                // Добавляем новое изображение
                await _libraryDbContext.Images.AddAsync(newImage);

                // Обновляем книгу с новым идентификатором изображения
                book.ImageId = newImage.Id;
                _libraryDbContext.Books.Update(book);

                await _libraryDbContext.SaveChangesAsync(cancellationToken);

                return newImage.Id;
            }
        }
    }
}
